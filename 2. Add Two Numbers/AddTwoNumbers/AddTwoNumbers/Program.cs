// See https://aka.ms/new-console-template for more information
using AddTwoNumbers;

Console.WriteLine("Hello, World!");
var a = 
    new ListNode(9, 
    new ListNode(9, 
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9
    )
    )
    )
    )
    )));
var b = 
    new ListNode(9,
    new ListNode(9,
    new ListNode(9,
    new ListNode(9
    )
    )));

var c = Solution.AddTwoNumbers(a, b);
Console.WriteLine(c.val);
Console.WriteLine(c.next.val);
Console.WriteLine(c.next.next.val);