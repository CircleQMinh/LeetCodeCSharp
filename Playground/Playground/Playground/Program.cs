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


//var s = new int[] { 1, 2 };
//var m = solution.FindPeakElement(s);

//var s1 = new int[] { 1, 1, 2 };
//var s2 = new int[] { 1,2,3};
//var k = 9;
//var r = solution.KSmallestPairs(s1,s2,k);

//MedianFinder medianFinder = new MedianFinder();
//medianFinder.AddNum(1);    // arr = [1]
//medianFinder.AddNum(2);    // arr = [1, 2]
//medianFinder.FindMedian(); // return 1.5 (i.e., (1 + 2) / 2)
//medianFinder.AddNum(3);    // arr[1, 2, 3]
//medianFinder.FindMedian(); // return 2.0

//var r = solution.AddBinary("11", "1");

//var s = new int[] { 9 };
//var r = solution.PlusOne(s);

//var s = solution.MyPow(2,10);

//var s = new int[][] { [4, 5], [4, -1], [4, 0] };
//var m = solution.MaxPoints(s);

//var s = new int[] { 2, 7, 9, 3, 1 };
//var r = solution.Rob(s);

//var s = "ddadddbdddadd";
//var w = new string[] { "dd", "ad", "da", "b" };
//var r = solution.WordBreak(s, w);

//var s = new int[] { 281, 20, 251, 251 };
//var w = 100;
//var r = solution.CoinChange(s, w);

//var s = new int[] { 0, 1, 0, 3, 2, 3 };
//var r = solution.LengthOfLIS(s);


//var s = new List<IList<int>>()
//{
//    new List<int> { 0 },
//    new List<int>  { 0, 4 },
//    //new List<int>  { 6, 5, 7 },
//    //new List<int>  { 4, 1, 8, 3 }
//};

//var r = solution.MinimumTotal(s);

//var s = new int[][]
//{
//   //[3,8,6,0,5,9,9,6,3,4,0,5,7,3,9,3],
//   //[0,9,2,5,5,4,9,1,4,6,9,5,6,7,3,2],
//   //[8,2,2,3,3,3,1,6,9,1,1,6,6,2,1,9],
//   //[1,3,6,9,9,5,0,3,4,9,1,0,9,6,2,7],
//   //[8,6,2,2,1,3,0,0,7,2,7,5,4,8,4,8],
//   //[4,1,9,5,8,9,9,2,0,2,5,1,8,7,0,9],
//   //[6,2,1,7,8,1,8,5,5,7,0,2,5,7,2,1],
//   //[8,1,7,6,2,8,1,2,2,6,4,0,5,4,1,3],
//   //[9,2,1,7,6,1,4,3,8,6,5,5,3,9,7,3],
//   //[0,6,0,2,4,3,7,6,1,3,8,6,9,0,0,8],
//   //[4,3,7,2,4,3,6,4,0,3,9,5,3,6,9,3],
//   //[2,1,8,8,4,5,6,5,8,7,3,7,7,5,8,3],
//   //[0,7,6,6,1,2,0,3,5,0,8,0,8,7,4,3],
//   //[0,4,3,4,9,0,1,9,7,7,8,6,4,6,9,5],
//   //[6,5,1,9,9,2,2,7,4,2,7,2,2,3,7,2],
//   //[7,1,9,6,1,2,7,0,9,6,6,4,4,5,1,0],
//   //[3,4,9,2,8,3,1,2,6,9,7,0,2,4,2,0],
//   //[5,1,8,8,4,6,8,5,2,4,1,6,2,2,9,7]
//[0,0,0],[0,1,0],[0,0,0]
//};
//var r = solution.UniquePathsWithObstacles(s);

//var s1 = "";
//var s2 = "";
//var s3 = "";
//var r = solution.IsInterleave(s1, s2, s3);


//var w1 = "horse";
//var w2 = "ros";
//var r = solution.MinDistance(w1, w2);

//var s = new int[] { 3, 2, 6, 5, 0, 3 };
//var r = solution.MaxProfitIV(2, s);

//var s = solution.CreateLinkedList(new List<int>() { 1, 2, 3, 4, 5 });
//var r = solution.ReverseKGroup(s,2);

//var s = new char[][] { ['0', '1'], ['1', '0'] };
//var r = solution.MaximalSquare(s);

//var s = "leet**cod*e";
//var r = solution.RemoveStars(s);

//var s = solution.CreateLinkedList(new List<int> { 1, 2, 3,4 });
//var r = solution.DeleteMiddle(s);

//var r = solution.NumTilings(100);

//var s = "ABABAB";
//var w = "ABAB";
//var r =  solution.GcdOfStrings(s, w);

//var s = solution.CreateLinkedList(new List<int> { 5,4,2,1 });
//var r = solution.PairSum(s);

//var s = new char[][]
//{
//    ['+','+','.','+'],['.','.','.','+'],['+','+','+','.']
//};
//var r = solution.NearestExit(s, new int[] {1,2});

//var s = new char[][]
//{
//    ['.','+']
//};
//var r = solution.NearestExit(s, new int[] { 0, 0 });


//var s = new char[][]
//{
//    ['.','.','.','.','.','+','.','.','.'],['.','+','.','.','.','.','.','.','.'],['.','.','+','.','+','.','+','.','+'],['.','.','.','.','+','.','.','.','.'],['.','.','.','.','+','+','.','.','.'],['+','.','.','.','.','.','.','.','.'],['.','.','.','+','.','.','.','.','.'],['.','.','.','+','.','.','.','.','+'],['+','.','.','+','.','+','+','.','.']
//};
// var r = solution.NearestExit(s, new int[] { 8, 4 });

//var s = solution.CreateTreeNode(new List<int?> { 2, 0, 34, null, 1, 25, 40, null, null, 11, 31, null, 45, 10, 18, 29, 32, 43, 46, 4, null, 12, 24, 26, 30, null, null, 42, 44, null, 48, 3, 9, null, 14, 22, null, null, 27, null, null, 41, null, null, null, 47, 49, null, null, 5, null, 13, 15, 21, 23, null, 28, null, null, null, null, null, null, null, 8, null, null, null, 17, 19, null, null, null, null, null, 7, null, 16, null, null, 20, 6 });
//var r = solution.DeleteNode(s, 33);

//var r = solution.Tribonacci(4);
//Action Write = () => Console.Write("Lol");
//var a = new Alarm(Write);
//a.Trigger();

//var s = solution.CreateTreeNode(new List<int?> { 1, 7, 0, 7, -8, null, null });
//var r = solution.MaxLevelSum(s);

var r = solution.SuccessfulPairs(new int[] { 5, 1, 3 }, new int[] {1,2,3,4,5 }, 7);


Console.WriteLine("Hello, World!");
