using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
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
            return _smallest;
        }

        public void AddBack(int num)
        {
            if (_removed.Remove(num))
            {
                _smallest = Math.Min(_smallest, num);
            }

        }
    }
}
