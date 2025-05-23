using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class DoublyLinkedList
    {
        public int val;
        public int key;
        public DoublyLinkedList prev;
        public DoublyLinkedList next;

        public DoublyLinkedList(int key, int val)
        {
            this.val = val;
            this.key = key;
            this.prev = null;
            this.next = null;
        }
    }
    public class LRUCache
    {
        private int _capacity;
        private Dictionary<int, DoublyLinkedList> _cache;
        private DoublyLinkedList _oldest;
        private DoublyLinkedList _latest;
        public LRUCache(int capacity)
        {
            _cache = new Dictionary<int, DoublyLinkedList>();
            _capacity = capacity;
            _oldest = new DoublyLinkedList(0, 0);
            _latest = new DoublyLinkedList(0, 0);
            _oldest.next = _latest;
            _latest.prev = _oldest;
        }

        public int Get(int key)
        {
            if (_cache.ContainsKey(key))
            {
                var node = _cache[key];
                RemoveNode(node);
                AddNode(node);
                return _cache[key].val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            var newNode = new DoublyLinkedList(key, value);
            if (_cache.ContainsKey(key))
            {
                var exist = _cache[key];
                RemoveNode(exist);

            }
            AddNode(newNode);
            _cache[key] = newNode;
            if (_capacity < _cache.Count)
            {
                _cache.Remove(_oldest.next.key);
                RemoveNode(_oldest.next);
            }

        }

        private void RemoveNode(DoublyLinkedList node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
        private void AddNode(DoublyLinkedList node)
        {
            _latest.prev.next = node;
            node.next = _latest;
            node.prev = _latest.prev;
            _latest.prev = node;
        }
    }
}