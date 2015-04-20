using System;

///<summory>
///Dijstra
///</summory>
namespace Islands_Travel
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] X = new int[size];
            int[] Y = new int[size];

            for (int i = 0; i < size; i++)
            {
                string[] words = Console.ReadLine().Split(' ');
                X[i] = int.Parse(words[0]);
                Y[i] = int.Parse(words[1]);
            }

            bool[] visited = new bool[size];
            int[] distance = new int[size];
            int min = 0, last = 0;
            for (int j = 1; j < size; j++)
            {
                distance[j] = caculate(X, Y, 0, j);
                min = distance[min] < distance[j] ? min : j;
            }
            distance[0] = int.MaxValue;
            for (int i = 1; i < size; i++)
            {
                visited[min] = true;
                last = min;
                min = 0;
                for (int j = 1; j < size; j++)
                {
                    if (!visited[j])
                    {
                        int tmp = distance[last] + caculate(X, Y, last, j);
                        distance[j] = distance[j] < tmp ? distance[j] : tmp;
                        min = distance[min] < distance[j] ? min : j;
                    }
                }
                if (min == size - 1)
                {
                    Console.WriteLine(min);
                }
            }

        }

        private static int caculate(int[] X, int[] Y, int i, int j)
        {
            int x = Math.Abs(X[i] - X[j]);
            int y = Math.Abs(Y[i] - Y[j]);

            return x < y ? x : y;
        }
    }
}
