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
            var n = word.Length;
            for (var i = 0; i < n; i++) {
                var c = word[i];
                if (!current.Children.ContainsKey(c))
                {
                    current.Children.Add(c, new TrieNode(c));
                }
                current = current.Children[c];
            }
            current.IsEnd = true;
        }

        public bool Search(string word)
        {
            var current = _root;
            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }
            return current.IsEnd;
        }

        public bool StartsWith(string prefix)
        {
            var current = _root;
            foreach (var c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }
            return true;
        }
    }

    public class TrieNode
    {
        public char val;
        public bool IsEnd;
        public Dictionary<char, TrieNode> Children;
        public TrieNode()
        {

            Children = new Dictionary<char, TrieNode>();

        }
        public TrieNode(char c)
        {
            val = c;
            Children = new Dictionary<char, TrieNode>();
        }
    }
}
