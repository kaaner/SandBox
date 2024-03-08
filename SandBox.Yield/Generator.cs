using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Yield
{
    public class Generator
    {
        static int counter = 0;
        public static IEnumerable<int> GetOddNumbers()
        {
            while (true)
            {
                counter++;

                if (counter % 2 == 1)
                    yield return counter;
            }
        }

        public static IEnumerable<string> GetStudents()
        {
            yield return ("Salih Cantekin");
            yield return ("Oğuz Kaplan");
            yield return ("Kerem Gün");
            yield return ("Ünal Top");
            yield return ("Emrah Yaman");


        }
    }
}
