// See https://aka.ms/new-console-template for more information
using Playground;
using System.Collections.Generic;

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

//LRUCache lRUCache = new LRUCache(1);
//lRUCache.Put(2, 1);
//lRUCache.Get(2);

//var s = solution.CreateTreeNode(new List<int?> { 1, 2, 3, 4, null, null, null, 5 });
////var s = solution.CreateNode(new List<int?> { 3, 9, 20, null, null, 15, 7 });
//var r = solution.RightSideView(s);


//var s = new char[][] {
//  [ '1','1','1','1','0' ],
//  [ '1','1','0','1','0' ],
//  [ '1','1','0','0','0' ],
//  [ '0','0','0','0','0' ]
//};
//var s1 = new char[][] {
//  ['1','1','0','0','0'],
//  ['1','1','0','0','0'],
//  ['0','0','1','0','0'],
//  ['0','0','0','1','1']
//};
//var r = solution.NumIslands(s1);


//var n1 = new Node(1);
//var n2 = new Node(2);
//var n3 = new Node(3);
//var n4 = new Node(4);

//n1.neighbors = new List<Node>() { n2,n4};
//n2.neighbors = new List<Node>() { n1,n3};
//n3.neighbors = new List<Node>() { n2, n4 };
//n4.neighbors = new List<Node>() { n1, n3 };

//var r = solution.CloneGraph(n1);

//var equas = new List<IList<string>>() { new List<string>(){ "a", "b" }, new List<string>() { "b", "c" } };
//var values = new double[] { 2.0, 3.0 };
//var queries = new List<IList<string>>() { 
//    new List<string>() { "a", "c" },
//    new List<string>() { "b", "a" }, 
//    new List<string>() { "a", "e" }, 
//    new List<string>() { "a", "a" }, 
//    new List<string>() { "x", "x" } };

//var r = solution.CalcEquation(equas,values,queries);

//var s = new int[][] { [-1, -1, 19, 10, -1], [2, -1, -1, 6, -1], [-1, 17, -1, 19, -1], [25, -1, 20, -1, -1], [-1, -1, -1, -1, 15] };
//var r = solution.SnakesAndLadders( s);


//var r = solution.MinMutation("AACCGGTT", "AAACGGTA", new string[] { "AACCGATT", "AACCGATA", "AAACGATA", "AAACGGTA" });


//var wd = new WordDictionary();
//wd.AddWord("at");
//wd.AddWord("and");
//wd.AddWord("an");
//wd.AddWord("add");
//var a1 = wd.Search("a");
//var a2 = wd.Search(".at");
//wd.AddWord("bat");
//var a3 = wd.Search(".at");
//var a4 = wd.Search(".an");






//var a5 = wd.Search("a.d");
//var a6 = wd.Search("b.");
//var a7 = wd.Search("a.d");
//var a8 = wd.Search(".");

//var s = new char[][] {
//    ['a','b'],['c','d']
//};
//var w = new string[] { "abcb" };

//var s = new char[][] {
//   ['a','b','c'],['a','e','d'],['a','f','g']
//};
//var w = new string[] { "abcdefg", "gfedcbaaa", "eaabcdgfa", "befa", "dgc", "ade" };

//var r = solution.FindWords(s, w);

//var n = 4;
//var k = 2;
//var r = solution.Combine(n, k);

//var n = 1;
//var r = solution.TotalNQueens(5);

//var s = new char[][] {
//    ['a','b'],['c','d']
//};

////var r = solution.Exist(s, "acdb");
//var s = new int[] { -10, -3, 0, 5, 9 };
//var r = solution.SortedArrayToBST(s);

//var s = solution.CreateLinkedList(new List<int> { 4, 2, 1, 3 });
//var r = solution.SortList(s);


//var s = new int[][] { [1, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 1, 1, 1, 1, 1], [1, 1, 1, 1, 1, 1, 1, 1], [1, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 1, 0, 0, 0, 0], [1, 1, 1, 1, 0, 0, 0, 0] };
//var r = solution.Construct(s);


var s = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
var m = solution.MaxSubArray(s);

Console.WriteLine("Hello, World!");
