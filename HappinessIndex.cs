using System;
using System.Text.RegularExpressions;


namespace HappinessIndex
{
    class HappinessIndex
    {
        static void Main()
        {
            Regex happy = new Regex(@"\:\)|\:D|\;\)|\:\*|\:\]|\;\]|\:\}|\;\}|\(\:|\*\:|c\:|\[\:|\[\;");

            Regex sad = new Regex(@"\:\(|D\:\|\;\(|\:\[|\;\[|\:\{|\;\{|\)\:|\:c|\]\:|\]\;");

            var input = Console.ReadLine();

            MatchCollection happyMatches = happy.Matches(input);
            MatchCollection sadMatches = sad.Matches(input);
            
            int happyCount = happyMatches.Count;
            int sadCount = sadMatches.Count;

            double happyIndex = happyCount / (double)sadCount;

            string status = "";

            if (happyIndex >=2)
            {
                status = ":D";
            }
            else if (happyIndex>1)
            {
                status = ":)";
            }
            else if (happyIndex == 1)
            {
                status = ":|";
            }
            else if (happyIndex <1)
            {
                status = ":(";
            }

            Console.WriteLine($"Happiness index: {happyIndex:F2} {status}");
            Console.WriteLine($"[Happy count: {happyCount}, Sad count: {sadCount}]");
        }
    }
}
