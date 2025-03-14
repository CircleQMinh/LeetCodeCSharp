using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class Trie
    {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var current = _root;
            foreach (var c in word)
            {
                if (!current.childs.Any(ch => ch.val.Equals(c)))
                {

                }
                else { 
                
                }
            }
        }

        public bool Search(string word)
        {

        }

        public bool StartsWith(string prefix)
        {

        }
    }

    public class TrieNode
    {
        public char val;
        public HashSet<TrieNode> childs;
        public TrieNode()
        {

            childs = new HashSet<TrieNode>();
        }
    }
}
