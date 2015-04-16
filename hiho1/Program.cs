using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///<summary>
///最长回文字串
///</summary>
namespace hiho1
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] results = new int[length];
            while (length-- > 0)
            {
                int len = 0;
                string line = Console.ReadLine();
                char[] array = line.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length; j++)
                    {

                        len = isPalindrome(array, i, j) ? (j - i + 1 > len ? j - i + 1 : len) : len;
                    }
                }

                results[length] = len;
            }

            for (int i = results.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(results[i]);
            }
        }

        private static bool isPalindrome(char[] array, int i, int j)
        {
            while (i < j)
            {
                if (array[i] == array[j])
                {
                    ++i;
                    --j;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
