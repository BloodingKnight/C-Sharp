using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hiho0
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                string[] tokens = line.Split(' ');
                Console.WriteLine(int.Parse(tokens[0]) + int.Parse(tokens[1]));
            }
        }
    }
}
