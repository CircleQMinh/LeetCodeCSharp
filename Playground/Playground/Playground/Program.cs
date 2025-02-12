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

var a = new int[7] { 10, 1, 2, 7, 6, 1, 5 };
var t = 8;
var r = solution.CombinationSum2(a,t);

Console.WriteLine("Hello, World!");
