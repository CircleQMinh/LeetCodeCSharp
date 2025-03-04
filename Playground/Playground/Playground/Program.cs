// See https://aka.ms/new-console-template for more information
using Playground;

Console.WriteLine("Hello, World!");
var solution = new Solution();
//var a = new char[9][] {
//['5', '3', '.', '.', '7', '.', '.', '.', '.'],
//['6', '.', '.', '1', '9', '5', '.', '.', '.'], 
//['.', '9', '8', '.', '.', '.', '.', '6', '.'], 
//['8', '.', '.', '.', '6', '.', '.', '.', '3'], 
//['4', '.', '.', '8', '.', '3', '.', '.', '1'], 
//['7', '.', '.', '.', '2', '.', '.', '.', '6'], 
//['.', '6', '.', '.', '.', '.', '2', '8', '.'], 
//['.', '.', '.', '4', '1', '9', '.', '.', '5'], 
//['.', '.', '.', '.', '8', '.', '.', '7', '9']} ;

//solution.SolveSudoku(a);

//var s = solution.CreateLinkedList(new List<int>() { 1, 4, 3, 2, 5, 2 });
//var r = solution.Partition(s,3);
//var r = solution.ReverseBetween(b, 1, 1);

//LRUCache lRUCache = new LRUCache(2);
//lRUCache.Put(1, 1); // cache is {1=1}
//lRUCache.Put(2, 2); // cache is {1=1, 2=2}
//lRUCache.Get(1);    // return 1
//lRUCache.Put(2, 2); // cache is {1=1, 2=2}
//lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
//lRUCache.Get(2);    // returns -1 (not found)
//lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
//lRUCache.Get(1);    // return -1 (not found)
//lRUCache.Get(3);    // return 3
//lRUCache.Get(4);    // return 4

LRUCache lRUCache = new LRUCache(1);
lRUCache.Put(2, 1);
lRUCache.Get(2);

Console.WriteLine("Hello, World!");
