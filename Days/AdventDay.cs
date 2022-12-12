namespace AdventOfCode2022.Days
{
    public abstract class AdventDay<InputType, OutputType>
    {
        public string InputRelativePath => $"./Data/{this.GetType().Name}.txt"; // this is just because it would annoy everyone that hates reflection. Hi Nat.

        public abstract List<InputType> InputData { get; set; }

        public abstract OutputType PartOneResult { get; set; }
        public abstract OutputType PartTwoResult { get; set; }

        public virtual void GetResult()
        {
            Console.WriteLine($"Part 1: {PartOne()}");
            Console.WriteLine($"Part 2: {PartTwo()}");
        }

        internal virtual OutputType PartOne()
        {
            throw new NotImplementedException();
        }

        internal virtual OutputType PartTwo()
        {
            throw new NotImplementedException();
        }
    }
}