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

    enum desiredOutcomePoints
    {
        X = 0, // lose
        Y = 3, // draw
        Z = 6  // win
    }

    enum desiredOutcomeIndex
    {
        X = 2, // lose
        Y = 1, // draw
        Z = 0  // win
    }

    enum playsAvailable
    {
        A = 1, // rock
        B = 2, // paper
        C = 3  // scissor
    }

    enum plays
    {
        Rock = 1, // rock
        Paper = 2, // paper
        Scissor = 3  // scissor
    }

    enum playsIndex
    {
        A = 0, // rock
        B = 1, // paper
        C = 2  // scissor
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

            if (!Enum.TryParse(play, out playsAvailable yindex)
               | !Enum.TryParse(outcome, out desiredOutcomeIndex xindex))
            {
                continue;
            }

            IPossiblePlay secondPlay = yindex switch
            {
                playsAvailable.A => new RockFirst(),
                playsAvailable.B => new PaperFirst(),
                playsAvailable.C => new ScissorsFirst(),
                _ => throw new NotImplementedException()
            };

            var score = secondPlay.Points
                        + (secondPlay.BeatenBy).GetPoints();

        }

        return PartTwoResult = total;
    }

    class RockFirst : IPossiblePlay
    {
        public int Points => 1;

        public IPossiblePlay BeatenBy => new PaperFirst();
        public IPossiblePlay Beats => new ScissorsFirst();
        public int GetPoints()
        {
            return Points;
        }
    }

    class PaperFirst : IPossiblePlay
    {
        public int Points => 2;

        public IPossiblePlay BeatenBy => new ScissorsFirst();
        public IPossiblePlay Beats => new RockFirst();

        public int GetPoints()
        {
            return Points;
        }
    }
    class ScissorsFirst : IPossiblePlay
    {
        public int Points => 3;

        public IPossiblePlay BeatenBy => new RockFirst();
        public IPossiblePlay Beats => new PaperFirst();

        public int GetPoints()
        {
            return Points;
        }
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
    }

}