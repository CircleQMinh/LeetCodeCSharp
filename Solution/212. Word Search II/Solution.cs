using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var m = board.Length;
            var n = board[0].Length;
            var result = new HashSet<string>();
            var root = new TrieNode();
            foreach (var word in words)
            {
                InsertIntoTrie(word, root);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (root.Children.ContainsKey(board[i][j]))
                    {
                        DFSWordOnBoard(board, "", root, (i, j), result);
                    }
                }
            }

            return result.ToList();
        }
        private void InsertIntoTrie(string word, TrieNode root)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.IsEnd = true;
        }

        public void DFSWordOnBoard(char[][] board, string word, TrieNode node, (int X, int Y) currentPos, HashSet<string> result)
        {
            var c = board[currentPos.X][currentPos.Y];
            if (!node.Children.ContainsKey(c))
            {
                return;
            }
            word += c;
            node = node.Children[c];

            if (node.IsEnd)
            {
                result.Add(word);
                node.IsEnd = false;
            }
            var directions = new (int X, int Y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var m = board.Length;
            var n = board[0].Length;

            board[currentPos.X][currentPos.Y] = '#';
            foreach (var dir in directions)
            {
                var newX = currentPos.X + dir.X;
                var newY = currentPos.Y + dir.Y;
                if (newX >= 0 && newX < m && newY >= 0 && newY < n && board[newX][newY] != '#')
                {
                    DFSWordOnBoard(board, word, node, (newX, newY), result);
                }
            }
            board[currentPos.X][currentPos.Y] = c;
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