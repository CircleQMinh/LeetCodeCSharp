﻿// See https://aka.ms/new-console-template for more information
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


var s = new char[][] {
  [ '1','1','1','1','0' ],
  [ '1','1','0','1','0' ],
  [ '1','1','0','0','0' ],
  [ '0','0','0','0','0' ]
};
var s1 = new char[][] {
  ['1','1','0','0','0'],
  ['1','1','0','0','0'],
  ['0','0','1','0','0'],
  ['0','0','0','1','1']
};
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

var equas = new List<IList<string>>() { new List<string>(){ "a", "b" }, new List<string>() { "b", "c" } };
var values = new double[] { 2.0, 3.0 };
var queries = new List<IList<string>>() { 
    new List<string>() { "a", "c" },
    new List<string>() { "b", "a" }, 
    new List<string>() { "a", "e" }, 
    new List<string>() { "a", "a" }, 
    new List<string>() { "x", "x" } };

var r = solution.CalcEquation(equas,values,queries);

Console.WriteLine("Hello, World!");
