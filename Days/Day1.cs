using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days;
class Day1 : AdventDay<int, int>
{
    public override List<int> InputData { get; set; } = new();
    public override int PartOneResult { get; set; }
    public override int PartTwoResult { get; set; }

    public Day1()
    {
        InputData = FileReader.ReadAsInt(InputRelativePath);
    }

    internal override int PartTwo()
    {
        var calorieTotals = new List<int>();
        var calorieRunningTotal = 0;

        foreach (var item in InputData)
        {

            if (item == 0)
            {
                calorieTotals.Add(calorieRunningTotal);

                //Reset Running Total
                calorieRunningTotal = 0;
            }

            calorieRunningTotal += item;
        }

        return PartTwoResult = calorieTotals.OrderByDescending(x => x).Take(3).Sum();
    }

    internal override int PartOne()
    {
        var maxCalories = 0;
        var calorieRunningTotal = 0;

        foreach (var item in InputData)
        {

            if (item == 0)
            {
                if (calorieRunningTotal > maxCalories)
                {
                    Console.WriteLine($"Elf was carrying {calorieRunningTotal} which is greater than the previous total.");
                    maxCalories = calorieRunningTotal;
                }

                calorieRunningTotal = 0;
            }

            calorieRunningTotal += item;
        }

        return PartOneResult = maxCalories;
    }
}

