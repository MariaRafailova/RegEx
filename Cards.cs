using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cards
{
    public class Cards
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"([1]?[0-9JQKA])([SHDC])";
            
            Regex regex = new Regex(pattern);

            MatchCollection cards = Regex.Matches(input, pattern);

            List<string> result = new List<string>();

            foreach (Match card in cards)
            {
                int power = 0;

                if (int.TryParse(card.Groups[1].Value, out power))
                {
                    if (power < 2 || power > 10)
                    {
                        continue;
                    }
                }                

                result.Add(card.Value);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
