using System;
using System.Diagnostics;

namespace SandBox.Addition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.Write("A = ");
            //int A = Convert.ToInt32(Console.ReadLine());

            //Console.Write("B = ");
            //int B = Convert.ToInt32(Console.ReadLine());

            int A = 12, B = 53;

            Addition instance = new Addition();
            AdditionArrayList instanceList = new AdditionArrayList();
            var result = instance.Add(A, B);
            var result2 = instanceList.Add(A, B);

            Console.WriteLine("T = " + result.ToString());
            Console.WriteLine("T2 = " + result2.ToString());

            ExecuteHighPerformance();
        }

        public static void ExecuteHighPerformance()
        {
            for (int d = 1; d < 50; d += 3)
            {

                Addition instance = new Addition();
                AdditionArrayList instanceList = new AdditionArrayList();

                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    instance.Add(13, 65);
                }
                timer.Stop();
                Console.WriteLine(d.ToString() + " ARRAY : " + timer.ElapsedMilliseconds.ToString() + "ms");

                timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    instanceList.Add(13, 65);
                }
                timer.Stop();
                Console.WriteLine(d.ToString() + " LIST  : " + timer.ElapsedMilliseconds.ToString() + "ms");
                Console.WriteLine();
            }

            Console.ReadLine();
        }


    }
}