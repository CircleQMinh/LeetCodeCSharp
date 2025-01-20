using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._Roman_to_Integer
{
    public class Solution
    {
        public int RomanToInt(string s)
        {
            // string[] M = { "", "M", "MM", "MMM" };
            // string[] C = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            // string[] X = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            // string[] I = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            // var list = new List<string>();
            // for (int i = 0; i < 4000; i++)
            // {
            //     list.Add(IntToRoman(i));
            // }

            // return list.IndexOf(s);
            var result = 0;
            s = s.Replace("IV", "IIII").Replace("IX", "IIIIIIIII");
            s = s.Replace("XL", "XXXX").Replace("XC", "XXXXXXXXX");
            s = s.Replace("CD", "CCCC").Replace("CM", "DCCCC");

            foreach (var item in s)
            {
                if (item.Equals('M'))
                {
                    result += 1000;
                }
                if (item.Equals('C'))
                {
                    result += 100;
                }
                if (item.Equals('X'))
                {
                    result += 10;
                }
                if (item.Equals('I'))
                {
                    result += 1;
                }

                if (item.Equals('D'))
                {
                    result += 500;
                }
                if (item.Equals('L'))
                {
                    result += 50;
                }
                if (item.Equals('V'))
                {
                    result += 5;
                }
            }

            return result;
        }
        // public static string IntToRoman(int num)
        // {
        //     var result = "";
        //     var numbers = new int[] {1000,500, };
        //     var s = 0;

        //     if (num >= 1000)
        //     {
        //         s = num / 1000;
        //         num = num % 1000;
        //         for (int i = 0; i < s; i++)
        //         {
        //             result += "M";
        //         }
        //     }


        //     if (num >= 100)
        //     {
        //         s = num / 100;
        //         if (s == 4)
        //         {
        //             result += "CD";
        //             s = 0;
        //         }
        //         else if (s == 9)
        //         {
        //             result += "CM";
        //             s = 0;
        //         }
        //         else
        //         {
        //             if (num >= 500)
        //             {
        //                 var s1 = num / 500;
        //                 num = num % 500;
        //                 for (int i = 0; i < s1; i++)
        //                 {
        //                     result += "D";
        //                 }
        //                 s = s - s1*5;
        //             }
        //         }
        //         num = num % 100;
        //         for (int i = 0; i < s; i++)
        //         {
        //             result += "C";
        //         }
        //     }


        //     if (num >= 10)
        //     {
        //         s = num / 10;
        //         if (s == 4)
        //         {
        //             result += "XL";
        //             s = 0;
        //         }
        //         else if (s == 9)
        //         {
        //             result += "XC";
        //             s = 0;
        //         }
        //         else
        //         {
        //             if (num >= 50)
        //             {
        //                 var s1 = num / 50;
        //                 num = num % 50;
        //                 for (int i = 0; i < s1; i++)
        //                 {
        //                     result += "L";
        //                 }
        //                 s = s - s1*5;
        //             }
        //         }
        //         num = num % 10;
        //         for (int i = 0; i < s; i++)
        //         {
        //             result += "X";
        //         }
        //     }

        //     s = num;
        //     if (num == 4)
        //     {
        //         result += "IV";
        //         s = 0;
        //     }
        //     else if (num == 9)
        //     {
        //         result += "IX";
        //         s = 0;
        //     }
        //     else
        //     {
        //         if (num >= 5)
        //         {
        //             var s1 = num / 5;
        //             num = num % 5;
        //             for (int i = 0; i < s1; i++)
        //             {
        //                 result += "V";
        //             }
        //             s = s - s1*5;
        //         }
        //     }
        //     for (int i = 0; i < s; i++)
        //     {
        //         result += "I";
        //     }
        //     return result;
        // }

    }
}
