using System;
using System.Collections.Generic;
using System.Linq;
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

    enum plays
    {
        A = 1, // rock
        B = 2, // paper
        C = 3  // scissor
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
    {
        var Matrix = new List<List<plays>>();

                                   // Z  (0)  // Y (1)   // X (2)
        Matrix.Add(new List<plays>() { plays.B, plays.A, plays.C }); // A (0) Rock
        Matrix.Add(new List<plays>() { plays.C, plays.B, plays.A }); // B (1) Paper
        Matrix.Add(new List<plays>() { plays.A, plays.C, plays.B }); // C (2) Scissor

        var total = 0;
        foreach (var item in InputData)
        {
          var play = item.Substring(0,1).Trim();
          var outcome = item.Substring(2, 1).Trim();

            var xindex = Enum.Parse(typeof(plays), play);
            Matrix
        }

        return ParTwoResult = total;
    }
}