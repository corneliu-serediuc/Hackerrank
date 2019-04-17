using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank.Challenges.UiPath
{
    public partial class Solution
    {
        static string GetGifName(string line)
        {
            return string.Empty;
        }

        private static void Main(string[] args)
        {
            // read the string filename
            string filename = "C:\\Users\\corneliu.serediuc\\Projects\\mylog.txt";

            StreamReader file = new StreamReader(filename);
            string line;

            Regex regex = new Regex(@"2\d{2}");

            while ((line = file.ReadLine()) != null)
            {
                Match match = regex.Match(line);

                if(match.Success)
                {
                    Console.WriteLine(line);
                }
            }

            file.Close();
        }
    }
}
