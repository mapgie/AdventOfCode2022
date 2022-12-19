using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days;

class Day2 : AdventDay<string, int>
{
    public override List<string> InputData { get; set; } = new();
    public override int PartOneResult { get; set; }
    public override int PartTwoResult { get; set; }

    public Day2()
    {
        InputData = FileReader.ReadAsString(InputRelativePath);
    }

    internal override int PartOne()
    {
        // this is ugly as hell
        var referenceValues = new Dictionary<string, int>();
        referenceValues.Add("B X", 1);  //I lose
        referenceValues.Add("C Y", 2);  //I lose
        referenceValues.Add("A Z", 3);  //I lose
        referenceValues.Add("A X", 4);  //We Tie
        referenceValues.Add("B Y", 5);  //We Tie
        referenceValues.Add("C Z", 6);  //We Tie
        referenceValues.Add("C X", 7);  //I win
        referenceValues.Add("A Y", 8);  //I win
        referenceValues.Add("B Z", 9);  //I win

        var total = 0;
        foreach (var item in InputData)
        {
            referenceValues.TryGetValue(item, out var score);
            total += score;
        }

        return PartOneResult = total;
    }

    class Rock : IPossiblePlay
    {
        public int Points => 1;

        public IPossiblePlay BeatenBy => new Paper();
        public IPossiblePlay Beats => new Scissors();

    }
    class Paper : IPossiblePlay
    {
        public int Points => 2;

        public IPossiblePlay BeatenBy => new Scissors();
        public IPossiblePlay Beats => new Rock();

    }
    class Scissors : IPossiblePlay
    {
        public int Points => 3;

        public IPossiblePlay BeatenBy => new Rock();
        public IPossiblePlay Beats => new Paper();

    }

    interface IPossiblePlay
    {
        public int Points { get; }

        public IPossiblePlay BeatenBy { get; }
        public IPossiblePlay Beats { get; }

        public int GetPoints()
        {
            return Points;
        }

        public string GetName()
        {
            return this.GetType().Name;
        }

    }

    enum desiredOutcomePoints
    {
        X = 0, // lose
        Y = 3, // draw
        Z = 6  // win
    }

    enum plays
    {
        A, // rock
        B, // paper
        C  // scissor
    }

    internal override int PartTwo()
    {                                                  // Win.Z.0       | Draw.Y.1       | Lose.X.2
        //var rockFirst = new List<playsAvailable>() { playsAvailable.B, playsAvailable.A, playsAvailable.C }; // A (0) Rock
        //var paperFirst = new List<playsAvailable>() { playsAvailable.C, playsAvailable.B, playsAvailable.A }; // B (1) Paper
        //var scissorFirst = new List<playsAvailable>() { playsAvailable.A, playsAvailable.C, playsAvailable.B }; // C (2) Scissor

        var total = 0;
        foreach (var item in InputData)
        {
            var play = item.Substring(0, 1).Trim();
            var outcome = item.Substring(2, 1).Trim();

            if (!Enum.TryParse(play, out plays firstPlay)
               | !Enum.TryParse(outcome, out desiredOutcomePoints desiredResult))
            {
                continue;
            }

            IPossiblePlay firstPlayDetails = firstPlay switch
            {
                plays.A => new Rock(),
                plays.B => new Paper(),
                plays.C => new Scissors(),
                _ => throw new NotImplementedException()
            };

            IPossiblePlay secondPlay = desiredResult switch
            {
                desiredOutcomePoints.X => firstPlayDetails.Beats,
                desiredOutcomePoints.Y => firstPlayDetails,
                desiredOutcomePoints.Z => firstPlayDetails.BeatenBy,
                _ => throw new NotImplementedException()
            };

            total += (int)desiredResult + secondPlay.GetPoints();

            //Console.WriteLine(
            //    $"({item}) - {firstPlayDetails.GetName()} | {secondPlay.GetType().Name} ({secondPlay.GetPoints()}pts) || {outcome} ({(int)desiredResult}pts)");

        }

        return PartTwoResult = total;
    }

}