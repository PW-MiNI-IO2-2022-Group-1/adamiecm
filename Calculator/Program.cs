using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        static string[] delimiters = { ",", "\n" };
        public static int CalculateString(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            string[] delims = delimiters;
            if(s.StartsWith("//"))
            {
                string[] parts = s.Split('\n', 2);
                delims = delims.Concat(AdditionalDelim(parts[0])).ToArray();
                
                s = parts[1];
            }
            int n = 0;
            int[] nums = s.Split(delims, StringSplitOptions.RemoveEmptyEntries)
                .Select(str => Int32.Parse(str))
                .Where(i => i <= 1000)
                .ToArray();

            if (nums.Any(n => n < 0)) throw new ArgumentException("negative number");
            return nums.Sum();
        }
        private static List<string> AdditionalDelim(string line)
        {
            List<string> l = new();
            if (line.ElementAt(2) == '[')
            {

                l.Add(line[3..^1]);
            }
            else
            {
                l.Add(line.ElementAt(2).ToString());
            }
            return l;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {

        }
    }
    
}

