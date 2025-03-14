using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class WordDictionary
    {
        private WordNode _root;
        public WordDictionary()
        {
            _root = new WordNode();
        }
        public void AddWord(string word)
        {
            var current = _root;
            var n = word.Length;
            for (var i = 0; i < n; i++)
            {
                var c = word[i];
                if (!current.childs.ContainsKey(c))
                {
                    current.childs.Add(c, new WordNode(c));
                }
                current = current.childs[c];
            }
            current.isEnd = true;
        }
        public bool Search(string word)
        {
            return SearchDFS(word, 0, _root);
        }
        private bool SearchDFS(string word, int index, WordNode node)
        {
            if (node == null) return false;
            if (index == word.Length) return node.isEnd;

            char c = word[index];
            if (c == '.')
            {
                foreach (var child in node.childs)
                {
                    if (SearchDFS(word, index + 1, child.Value))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (node.childs.ContainsKey(c))
                {
                    return SearchDFS(word, index + 1, node.childs[c]);
                }
                return false;
            }
        }
        //public bool Search(string word)
        //{
        //    var queue = new Queue<WordNode>();
        //    queue.Enqueue(_root);

        //    foreach (var c in word)
        //    {
        //        var count = queue.Count;
        //        if (c.Equals('.'))
        //        {
        //            for (var i = 0; i < count; i++)
        //            {
        //                var current = queue.Dequeue();
        //                foreach (var childKey in current.childs.Keys)
        //                {
        //                    queue.Enqueue(current.childs[childKey]);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            for (var i = 0; i < count; i++)
        //            {
        //                var current = queue.Dequeue();
        //                if (current.childs.ContainsKey(c))
        //                {
        //                    queue.Enqueue(current.childs[c]);
        //                }
        //            }
        //        }



        //    }

        //    return queue.Any(q=>q.isEnd);
        //}

    }
    public class WordNode
    {
        public char val;
        public bool isEnd;
        public Dictionary<char, WordNode> childs;
        public WordNode()
        {

            childs = new Dictionary<char, WordNode>();

        }
        public WordNode(char c)
        {
            val = c;
            childs = new Dictionary<char, WordNode>();
        }
    }
}
