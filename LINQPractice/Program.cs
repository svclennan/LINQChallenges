using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" };
            List<string> output = SubstringTH(words);
            foreach (string word in output)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();

            List<string> names = new List<string>() { "Mike", "Brad", "Nevin", "Ian", "Mike" };
            output = Duplicates(names);
            foreach (string word in output)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();

            List<string> classGrades = new List<string>() { "80,100,92,89,65", "93,81,78,84,69", "73,88,83,99,64", "98,100,66,74,55" };
            Console.WriteLine(AverageLINQ(classGrades));
            Console.WriteLine();

            string name = "Terrill";
            Console.WriteLine(LetterFrequency(name));
            Console.WriteLine();

            Console.ReadLine();
        }
        public static List<string> SubstringTH(List<string> words)
        {
            List<string> result = new List<string>();
            var substrings = words.Where(w => w.Contains("th"));
            foreach (var word in substrings)
            {
                result.Add(word);
            }
            return result;
        }
        
        public static List<string> Duplicates(List<string> words)
        {
            var result = words.Distinct();
            return result.ToList();
        }
        
        public static double Averages(List<string> grades)
        {
            double avg;
            List<double> studentAverage = new List<double>();
            foreach (var studentGrade in grades)
            {
                string[] strings = studentGrade.Split(',');
                List<int> integers = new List<int>();
                foreach (string character in strings)
                {
                    integers.Add(Convert.ToInt32(character));
                }
                integers.Remove(integers.Min());
                studentAverage.Add(integers.Average());
            }
            avg = studentAverage.Average();
            return avg;
        }

        public static double AverageLINQ(List<string> grades)
        {
            return grades.Select(g => g.Split(','))
                         .Select(y => y.Select(z => Double.Parse(z)).OrderBy(x => x).Skip(1))
                         .SelectMany(x => x).Average();
        }

        public static string LetterFrequency(string name)
        {
            var result = name.ToUpper().Select(n => n).GroupBy(n => n).OrderBy(n => n.Key);
            var output = result.Select(x => x.Key.ToString() + x.Count());

            return String.Join("", output);
        }
    }
}