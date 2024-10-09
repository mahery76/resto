using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleExample
{
    public class NumberGenerator
    {
        public IEnumerable<int> GenerateNumbers(int count)
        {
            return Enumerable.Range(1, count);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new NumberGenerator();
            var numbers = generator.GenerateNumbers(5);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

