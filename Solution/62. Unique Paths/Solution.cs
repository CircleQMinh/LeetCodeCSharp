using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }
            return dp[m - 1, n - 1];
        }
        //public int UniquePaths(int m, int n)
        //{
        //    var solutions = new HashSet<List<(int X, int Y)>>();
        //    FindUniquePaths(m,n,(0,0),new List<(int X, int Y)>(),solutions);
        //    return solutions.Count;
        //}

        //public void FindUniquePaths(int m, int n, (int X, int Y) current, List<(int X,int Y)> currentPath, HashSet<List<(int X, int Y)>> solutions)
        //{
        //    if (current.X == m-1 && current.Y == n-1)
        //    {
        //        var newSolution = new List<(int X,int Y)>(currentPath);
        //        solutions.Add(newSolution);
        //    }
        //    var directions = new (int X, int Y)[] {  (1, 0), (0, 1) };
        //    foreach (var (dx, dy) in directions)
        //    {
        //        int newX = current.X + dx, newY = current.Y + dy;

        //        if (newX >= 0 && newX < m && newY >= 0 && newY < n) // Valid location 
        //        {
        //            currentPath.Add((newX, newY));
        //            FindUniquePaths(m,n,(newX,newY),currentPath,solutions);
        //            currentPath.RemoveAt(currentPath.Count - 1);
        //        }
        //    }
        //}
    }
}