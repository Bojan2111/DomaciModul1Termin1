using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortiranje
{
    internal class Program
    {
        static void Main()
        {
            string testString = "RWRzBRAaBWARwBZ";
            RastuciSort(testString);
            OpadajuciSort(testString);

            Console.ReadKey();
        }

        public static void RastuciSort(string zaSortiranje)
        {
            char[] slova = zaSortiranje.ToCharArray();

            for (int i = 0; i < slova.Length; i++)
            {
                for (int j = i + 1; j < slova.Length; j++)
                {
                    if (slova[i].CompareTo(slova[j]) > 0)
                    {
                        char temp = slova[i];
                        slova[i] = slova[j];
                        slova[j] = temp;
                    }
                }
            }

            Console.WriteLine(new String(slova));
        }

        public static void OpadajuciSort(string zaSortiranje)
        {
            char[] slova = zaSortiranje.ToCharArray();

            for (int i = 0; i < slova.Length; i++)
            {
                for (int j = i + 1; j < slova.Length; j++)
                {
                    if (slova[i].CompareTo(slova[j]) < 0)
                    {
                        char temp = slova[i];
                        slova[i] = slova[j];
                        slova[j] = temp;
                    }
                }
            }

            Console.WriteLine(new String(slova));
        }
    }
}
