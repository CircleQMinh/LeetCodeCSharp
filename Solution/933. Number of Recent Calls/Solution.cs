using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class RecentCounter
    {

        private Queue<int> _queue;
        private const int _limit = 3000;
        public RecentCounter()
        {
            _queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            _queue.Enqueue(t);
            while (_queue.Count > 0 && _queue.Peek() + _limit < t)
            {
                _queue.Dequeue();
            }
            return _queue.Count();
        }
    }

    /**
     * Your RecentCounter object will be instantiated and called as such:
     * RecentCounter obj = new RecentCounter();
     * int param_1 = obj.Ping(t);
     */
}