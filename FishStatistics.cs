using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FishStatistics
{
    public class FishStatistics
    {
        public static void Main()
        {
            string input = Console.ReadLine();                

            string pattern = @"(>*)<(\(+?)('|-|x)>";           

            Regex regex = new Regex(pattern);

            //var matches = regex.Matches(input);

            MatchCollection fishes = Regex.Matches(input, pattern);

            var count = 1;
            foreach (Match fish in fishes)
            {              
                Console.WriteLine($"Fish {count}: { fish.Value}");
                
                if (fish.Groups[1].Length >5)
                {
                    Console.WriteLine($"Tail type: Long ({fish.Groups[1].Length*2} cm)");
                }
                else if (fish.Groups[1].Length > 1 && fish.Groups[1].Length <=5)
                {
                    Console.WriteLine($"Tail type: Medium ({fish.Groups[1].Length * 2} cm)");
                }
                else if (fish.Groups[1].Length == 1)
                {
                    Console.WriteLine($"Tail type: Short ({fish.Groups[1].Length * 2} cm)");
                }
                else 
                {
                    Console.WriteLine($"Tail type: None");
                }

                
                if (fish.Groups[2].Length > 10)
                {
                    Console.WriteLine($"Body type: Long ({fish.Groups[2].Length * 2} cm)");
                }
                else if (fish.Groups[2].Length > 5 && fish.Groups[2].Length <= 10)
                {
                    Console.WriteLine($"Body type: Medium ({fish.Groups[2].Length * 2} cm)");
                }
                else if (fish.Groups[2].Length <= 5)
                {
                    Console.WriteLine($"Body type: Short ({fish.Groups[2].Length * 2} cm)");
                }

               
                if (fish.Groups[3].Value == "'")
                {
                    Console.WriteLine("Status: Awake");
                }
                else if (fish.Groups[3].Value == "-")
                {
                    Console.WriteLine("Status: Asleep");
                }
                else if (fish.Groups[3].Value == "x")
                {
                    Console.WriteLine("Status: Dead");
                }

                count++;
            }

            if (fishes.Count < 1)
            {
                Console.WriteLine("No fish found.");
            }
        }
    }
}
