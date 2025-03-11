using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var dictionary = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; i++)
            {
                dictionary.Add(i, new List<int>());
            }
            foreach (var item in prerequisites)
            {
                var need = item[0];
                var pre = item[1];
                dictionary[need].Add(pre);
            }
            foreach (var item in dictionary)
            {
                if (!CanFinishCourse(item.Key, dictionary, new HashSet<int>()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanFinishCourse(int courseNumber, Dictionary<int, List<int>> prerequisites, HashSet<int> taken)
        {
            if (prerequisites[courseNumber].Count == 0)
            {
                return true;
            }
            if (!taken.Add(courseNumber))
            {
                return false;
            }

            foreach (var item in prerequisites[courseNumber])
            {
                if (!CanFinishCourse(item, prerequisites, taken))
                {
                    return false;
                }
            }
            // the course is proved to be valid, remove all of it prerequisites
            prerequisites[courseNumber].Clear();

            return true;
        }

    }
}