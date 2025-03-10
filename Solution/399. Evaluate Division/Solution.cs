using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var result = new double[queries.Count];
            var map = new Dictionary<(string x, string y), double>();
            var list = new Dictionary<string, Node>();

            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                var v1 = equation[0];
                var v2 = equation[1];
                var value = values[i];

                Node currentV1 = !list.ContainsKey(v1) ? new Node(v1) : currentV1 = list[v1]; if (!list.ContainsKey(v1)) list.Add(v1, currentV1);
                Node currentV2 = !list.ContainsKey(v2) ? new Node(v2) : currentV2 = list[v2]; if (!list.ContainsKey(v2)) list.Add(v2, currentV2);

                if (!currentV1.neighbors.Contains(currentV2))
                {
                    currentV1.neighbors.Add(currentV2);
                }

                if (!currentV2.neighbors.Contains(currentV1))
                {
                    currentV2.neighbors.Add(currentV1);
                }

                if (!map.ContainsKey((v1, v2)))
                {
                    map.Add((v1, v2), value);
                    map.Add((v2, v1), 1 / value);
                }
            }

            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                var v1 = query[0];
                var v2 = query[1];

                if (!list.ContainsKey(v1) || !list.ContainsKey(v2))
                {
                    result[i] = (-1);
                    continue;
                }

                Node currentV1 = list[v1];
                Node currentV2 = list[v2];
                var path = FindPathFromV1ToV2(currentV1, currentV2, new List<string>(), new List<string>());
                if (path.Count == 0)
                {
                    result[i] = (-1);
                    continue;
                }
                var cal = 1d;
                for (int j = 0; j < path.Count - 1; j++)
                {
                    cal *= map[(path[j], path[j + 1])];
                }
                result[i] = (cal);
            }



            return result;
        }

        public List<string> FindPathFromV1ToV2(Node v1, Node v2, List<string> current, List<string> visited)
        {
            current.Add(v1.val);
            visited.Add(v1.val);
            if (v1.val == v2.val)
            {
                return current;
            }
            foreach (var item in v1.neighbors)
            {
                if (!visited.Contains(item.val))
                {
                    var s = FindPathFromV1ToV2(item, v2, current, visited);
                    if (s.Count > 0)
                    {
                        return s;
                    }
                    current.Remove(item.val);
                }
            }
            current.Remove(v1.val);
            return new List<string>();

        }
    }
    public class Node
    {
        public string val;
        public IList<Node> neighbors;

        public Node()
        {
            val = "";
            neighbors = new List<Node>();
        }

        public Node(string _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(string _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}