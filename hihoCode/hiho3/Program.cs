using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///<summary>
///Trie tree
///</summary>
namespace hiho3
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieTree tree = new TrieTree();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                tree.accept(Console.ReadLine());
            }
            int test = int.Parse(Console.ReadLine());
            for (int i = 0; i < test; i++)
            {
                Console.WriteLine(tree.match(Console.ReadLine()));
            }
        }

    }
    class TrieTree
    {
        public bool isLeaf { get; set; }

        public int count { get; set; }

        private Dictionary<char, TrieTree>  dict = new Dictionary<char, TrieTree>();

        public TrieTree this[char key]
        {
            get
            {
                try
                {
                    return dict[key];
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                dict[key] = value;
            }
        }

        public TrieTree() { count = 1; }

        public void accept(string line) 
        {
            TrieTree cur = this;
            foreach (var c in line)
            {
                if (cur[c] == null)
                {
                    cur[c] = new TrieTree();
                }
                else
                {
                    cur[c].count++;
                }
                cur = cur[c];
            }
        }

        public int match(string test) 
        {
            TrieTree cur = this;
            foreach (var c in test)
            {
                if (cur[c] == null)
                {
                    return 0;
                }
                cur = cur[c];
            }
            return cur.count;
        }
    }
}
