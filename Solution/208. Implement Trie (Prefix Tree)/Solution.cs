using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
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
            for (var i = 0; i < n; i++)
            {
                var c = word[i];
                if (!current.childs.ContainsKey(c))
                {
                    current.childs.Add(c, new TrieNode(c));
                }
                current = current.childs[c];
            }
            current.isEnd = true;
        }

        public bool Search(string word)
        {
            var current = _root;
            foreach (var c in word)
            {
                if (!current.childs.ContainsKey(c))
                {
                    return false;
                }
                current = current.childs[c];
            }
            return current.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            var current = _root;
            foreach (var c in prefix)
            {
                if (!current.childs.ContainsKey(c))
                {
                    return false;
                }
                current = current.childs[c];
            }
            return true;
        }
    }

    public class TrieNode
    {
        public char val;
        public bool isEnd;
        public Dictionary<char, TrieNode> childs;
        public TrieNode()
        {

            childs = new Dictionary<char, TrieNode>();

        }
        public TrieNode(char c)
        {
            val = c;
            childs = new Dictionary<char, TrieNode>();
        }
    }
}