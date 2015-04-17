using System;
using System.Collections.Generic;
using System.Text;

namespace Professor_Q_s_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            List<Software> sys = new List<Software>();
            for (int i = 0; i < size; i++)
            {
                sys.Add(new Software());
            }
            for (int i = 0; i < size; i++)
            {
                sys[i].print();
            }
        }
    }

    class Software
    {
        private Module[] modules;
        Signals signals = new Signals();
        string[] starts;

        public Software()
        {
            string line = Console.ReadLine();
            string[] tmp = line.Split(' ');
            int m = int.Parse(tmp[0]);
            int n = int.Parse(tmp[1]);

            modules = new Module[m];

            line = Console.ReadLine();
            starts = line.Split(' ');

            for (int j = 0; j < m; j++)
            {
                line = Console.ReadLine();
                tmp = line.Split(' ');
                int length = int.Parse(tmp[1]);
                Module module = new Module(length);
                signals[tmp[0]].Add(module);
                modules[j] = module;
                for (int k = 0; k < length; k++)
                {
                    module[k] = tmp[k + 2];
                }
            }

            for (int j = 0; j < n; j++)
            {
                run(starts[j]);
            }
        }

        public void run(string name)
        {
            foreach (var module in signals[name])
            {
                module.count++;
                for (int i = 0; i < module.size; i++)
                {
                    run(module[i]);
                }
            }
        }

        public void print()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var module in modules)
            {
                builder.Append(module.count).Append(' ');
            }
            Console.WriteLine(builder.ToString());
        }
    }

    class Module
    {
        private string[] signals;

        public int count { get; set; }

        public int size { get; set; }

        public Module() { count = 0; }

        public Module(int size) { signals = new string[size]; count = 0; this.size = size; }

        public string this[int key]
        {
            get
            {
                return signals[key];
            }
            set
            {
                signals[key] = value;
            }
        }
    }

    class Signals
    {
        private Dictionary<string, List<Module>> data = new Dictionary<string, List<Module>>();

        public List<Module> this[string key] 
        {
            get 
            {
                if (!data.ContainsKey(key))
                {
                    data.Add(key, new List<Module>());
                }
                return data[key];
            } 
        }
    }

}
