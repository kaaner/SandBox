using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SandBox.HashSet // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HashSet<string> hashSet = new HashSet<string>();

            "Burak".GetHashCode();
            var result1 = hashSet.Add("Burak");
            var result2 = hashSet.Add("Ece");
            var result3 = hashSet.Add("Ece");
            Console.WriteLine($"Set Info = {string.Join('-', hashSet.ToList())}");
            Console.WriteLine(result1 + "-" + result2 + "-" + result3 + " set count :" + hashSet.Count);
            //var result4 = hashSet.Remove("Burak");
            //var result5 = hashSet.Remove("Burak");
            //Console.WriteLine(result4 + "-" + result5 + " set count :" + hashSet.Count);

            var result6 = hashSet.RemoveWhere(p => p.Equals("Ece"));
            Console.WriteLine(result6 + " set count :" + hashSet.Count);
            Console.WriteLine($"Set Info = {string.Join('-', hashSet.ToList())}");

            bool resultContains = hashSet.Contains("Ece");
            //ExecutePerformance();
            ExecuteHighPerformance();
        }

        public static void ExecutePerformance()
        {
            Stopwatch _stopwatch = new Stopwatch();

            for (int d = 0; d < 5; d++)
            {
                List<string> list = new List<string>();
                HashSet<string> hashSet = new HashSet<string>();
                Console.WriteLine("**************Test" + d + "**************");

                _stopwatch.Start();
                Console.WriteLine("List.Add Start Count : 1000000");

                for (int i = 0; i < 1000000; i++)
                {
                    list.Add("Burak_" + i);
                }

                _stopwatch.Stop();
                Console.WriteLine("List.Add Finish Result_ms :" + _stopwatch.ElapsedMilliseconds);

                _stopwatch.Restart();
                _stopwatch.Start();
                Console.WriteLine("hashSet.Add Start Count : 1000000");

                for (int j = 0; j < 1000000; j++)
                {
                    hashSet.Add("Burak_" + j);
                }

                _stopwatch.Stop();
                Console.WriteLine("hashSet.Add Finish Result_ms :" + _stopwatch.ElapsedMilliseconds);
                _stopwatch.Restart();
            }
            Console.ReadLine();
        }

        public static void ExecuteHighPerformance()
        {
            for (int d = 1; d < 50; d += 3)
            {
                List<object> list = new List<object>();
                HashSet<object> hashset = new HashSet<object>();

                for (int i = 0; i < d; i++)
                {
                    list.Add(new object());
                    hashset.Add(new object());
                }

                object objToAddRem = list[0];

                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    list.Remove(objToAddRem);
                    list.Add(objToAddRem);
                }
                timer.Stop();
                Console.WriteLine(d.ToString() + " LIST : " + timer.ElapsedMilliseconds.ToString() + "ms");

                timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    hashset.Remove(objToAddRem);
                    hashset.Add(objToAddRem);
                }
                timer.Stop();
                Console.WriteLine(d.ToString() + " HASHSET  : " + timer.ElapsedMilliseconds.ToString() + "ms");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}