using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public string PredictPartyVictory(string senate)
        {
            var queue = new Queue<int>();
            var list = senate.ToCharArray().ToList();
            var disabled = 'O';

            for (var i = 0; i < list.Count; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (int i = 0; i < count; i++) // every round
                {
                    var currentIndex = queue.Dequeue();
                    var current = list[currentIndex];
                    if (current != disabled)  // if still have right
                    {
                        var opponent = current == 'R' ? 'D' : 'R';
                        var opponentIndex = -1;

                        for (int j = currentIndex + 1; j < list.Count; j++) // find first opponent have not vote
                        {
                            if (list[j] == opponent)
                            {
                                opponentIndex = j;
                                break;
                            }
                        }

                        for (int j = 0; j < list.Count && opponentIndex < 0; j++) // find first opponent 
                        {
                            if (list[j] == opponent)
                            {
                                opponentIndex = j;
                                break;
                            }
                        }
                        if (opponentIndex < 0) // if there is no opponent -> win
                        {
                            return current == 'R' ? "Radiant" : "Dire";
                        }
                        list[opponentIndex] = disabled;
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] != disabled)
                    {
                        queue.Enqueue(i);
                    }
                }

            }
            return ":D";
        }
    }
}