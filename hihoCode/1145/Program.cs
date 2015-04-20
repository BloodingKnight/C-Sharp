using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1145
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] tmp = line.Split(' ');
            int length = int.Parse(tmp[0]);
            int days = int.Parse(tmp[1]);

            Tree tree = new Tree();
            int[] results = new int[days];

            for (int i = 0; i < length - 1; i++)
            {
                line = Console.ReadLine();
                tmp = line.Split(' ');
                tree.addEdge(int.Parse(tmp[0]), int.Parse(tmp[1]));
            }

            for (int i = 0; i < days; i++)
            {
                line = Console.ReadLine();
                tmp = line.Split(' ');
                results[i] = tree.subTrees(int.Parse(tmp[0]), int.Parse(tmp[1]));
            }

            for (int i = 0; i < days; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }

    class Tree
    {
        private Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        public Node this[int key]
        {
            get
            {
                if (!nodes.ContainsKey(key))
                {
                    nodes.Add(key, new Node(key));
                }
                return nodes[key];
            }
        }

        public void addEdge(int from, int to)
        {
            this[from].nextTo(this[to]);
            this[to].nextTo(this[from]);
        }

        public int subTrees(int from, int to)
        {
            bool[] visited = new bool[to - from + 1];
            int count = 0;
            for (int i = from; i <= to; i++)
            {
                if (visited[i - from])
                {
                    continue;
                }
                visit(i, visited, from, to);
                ++count;
            }
            return count;
        }

        private void visit(int i, bool[] visited, int from, int to)
        {
            foreach (var item in this[i].siblings)
            {
                if (item.val >= from && item.val <= to && !visited[item.val - from])
                {
                    visited[item.val - from] = true;
                    visit(item.val, visited, from, to);
                }
            }
        }
    }

    class Node
    {
        public List<Node> siblings { get; set; }
        public int val { get; set; }

        public Node() { this.siblings = new List<Node>(); }
        public Node(int val) { this.val = val; this.siblings = new List<Node>(); }

        public void nextTo(Node node)
        {
            siblings.Add(node);
        }
    }
}
