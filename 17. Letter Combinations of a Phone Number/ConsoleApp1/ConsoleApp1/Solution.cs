using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            var map = new List<string>{
                 "","","abc","def","ghi","jkl","mno","pqrs","tuv","wxyz"
                };
            var list = new List<string>();
            if (digits.Length == 0)
            {
                return list;
            }
            Recursion(digits, "", digits.Length,map, list);
            return list;
        }

        public void Recursion(string input, string current, int len, List<string> map, List<string> result)
        {
            result = result ?? new List<string>();
            if (current.Length == len)
            {
                result.Add(current);
                return;
            }

            var currentNumberOfInput = int.Parse(""+input[current.Length]);
            var currentLetters = map[currentNumberOfInput];
            for (int i = 0; i < currentLetters.Length; i++) {
                Recursion(input, current + currentLetters[i], len, map, result);
            }

        }
    }
}
