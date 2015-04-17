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
            while (length-- > 0)
            {
                int len = 1;
                string line = Console.ReadLine();
                int strLen = line.Length;
                int[,] visited = new int[strLen, strLen];
                for (int i = 0; i < strLen; i++)
                {
                    for (int j = i + 1; j < strLen; j++)
                    {
                        bool flag = isPalindrome(line, i, j, visited);
                        if (flag)
                        {
                            int tmp = j - i + 1;
                            len = len > tmp ? len : tmp;
                            visited[i, j] = 1;
                        }
                        else
                        {
                            int tmpI = i, tmpJ = j;
                            while (tmpI >= 0 && tmpJ < length)
                            {
                                visited[tmpI, tmpJ] = -1;
                                --tmpI;
                                ++tmpJ;
                            }
                        }
                    }
                }

                results[length] = len;
            }

            for (int i = results.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(results[i]);
            }
        }

        private static bool isPalindrome(string line, int i, int j, int[, ] visited)
        {
            switch (visited[i, j])
            {
                case 1:
                    return true;
                case -1:
                    return false;
                default:
                    while (i < j)
                    {
                        if (line[i] == line[j])
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
}
