using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class SmallestInfiniteSet
    {

        private int _smallest;
        private HashSet<int> _removed;
        public SmallestInfiniteSet()
        {
            _smallest = 1;
            _removed = new HashSet<int>();
        }

        public int PopSmallest()
        {
            while (_removed.Contains(_smallest))
            {
                _smallest++;
            }
            var result = _smallest;
            _removed.Add(_smallest);
            _smallest++;

            return result;
        }

        public void AddBack(int num)
        {
            if (_removed.Remove(num))
            {
                _smallest = Math.Min(_smallest, num);
            }

        }
    }

    /**
     * Your SmallestInfiniteSet object will be instantiated and called as such:
     * SmallestInfiniteSet obj = new SmallestInfiniteSet();
     * int param_1 = obj.PopSmallest();
     * obj.AddBack(num);
     */
}