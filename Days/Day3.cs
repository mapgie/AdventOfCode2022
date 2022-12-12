using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days;

class Day3 : AdventDay<string, int>
{
    public override List<string> InputData { get; set; } = new();
    public override int PartOneResult { get; set; }
    public override int PartTwoResult { get; set; }

    public Day3()
    {
        InputData = FileReader.ReadAsString(InputRelativePath);
    }

    public override void GetResult()
    {

        foreach (var item in InputData)
        {
            Console.WriteLine(item);
        }

    }

    internal override int PartOne()
    {
        return 0;
    }

    internal override int PartTwo()
    {
        return 0;
    }
}
