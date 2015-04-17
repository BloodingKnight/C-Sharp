using System;

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
            for (int i = 0; i < length; i++)
            {
                string line = Console.ReadLine();
                int max = 0, tmp = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    tmp = getMaxPalindrome(line, j - 1, j + 1);
                    max = max > tmp ? max : tmp;
                    tmp = getMaxPalindrome(line, j, j + 1);
                    max = max > tmp ? max : tmp;
                }
                results[i] = max;
            }

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(results[i]);
            }

        }

        private static int getMaxPalindrome(string line, int i, int j)
        {
            while (i >= 0 && j < line.Length && line[i] == line[j])
            {
                --i;
                ++j;
            }

            return j - i - 1;
        }

    }
}
