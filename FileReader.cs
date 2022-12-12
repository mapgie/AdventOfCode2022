using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class FileReader
    {
        public static List<int> ReadAsInt(string inputRelativePath)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = System.IO.Path.Combine(currentDirectory, inputRelativePath);
            string filePath = Path.GetFullPath(file);

            var inputContent = File.ReadAllLines(filePath);

            var returnList = new List<int>();

            foreach (var input in inputContent)
            {
                int.TryParse(input, out var inputAsInt);
                returnList.Add(inputAsInt);
            }

            return returnList;
        }

        public static List<string> ReadAsString(string inputRelativePath)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = System.IO.Path.Combine(currentDirectory, inputRelativePath);
            string filePath = Path.GetFullPath(file);

            var inputContent = File.ReadAllLines(filePath);

            return new List<string>(inputContent);
        }
    }
}
