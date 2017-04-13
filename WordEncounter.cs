using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace WordEncounter
{
    public class WordEncounter
    {
        public static void Main()
        {
            List<string> result = new List<string>();

            //var wordsInSent = new List<string>();

            string filter = Console.ReadLine();

            var character = filter[0];
            int digit = int.Parse(filter[1].ToString());
           
            var sentence = Console.ReadLine();

            while (sentence != "end")
            {
                Regex start = new Regex(@"^[A-Z]");
                Regex end = new Regex(@"[.!?]$");

                bool validStart = start.IsMatch(sentence);
                bool validEnd = end.IsMatch(sentence);

                if (validStart && validEnd)
                {
                    var newSentence = sentence
                        .Split(new[] { ',', '.', ' ','!', '?',';', ':','(',')', '*'}, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    foreach (var word in newSentence)
                    {
                        int counter = 0;
                        int index = word.IndexOf(character);
                        while (index != -1)
                        {
                            counter++;
                            index = word.IndexOf(character, index + 1);
                        }

                        if (counter == digit)
                        {
                            result.Add(word);
                        }

                    }
                        //    string pattern = @"[a-zA-Z]*";

                        //    Regex allWords = new Regex(pattern);

                        //    MatchCollection words = Regex.Matches(sentence, pattern);

                        //    foreach (Match word in words)
                        //    {
                        //        wordsInSent.Add(word.Value);
                        //    }

                        //    foreach (var w in wordsInSent)
                        //    {
                        //        int counter = 0;
                        //        int index = w.IndexOf(character);
                        //        while (index != -1)
                        //        {
                        //            counter++;
                        //            index = w.IndexOf(character, index + 1);
                        //        }

                        //        if (counter == digit)
                        //        {
                        //            result.Add(w);
                        //        }
                        //     }
                    }

                sentence = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", result));

        }
    }
}
