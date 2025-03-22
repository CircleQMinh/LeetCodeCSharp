using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            var set = coins.Distinct().ToHashSet();
            var memo = new Dictionary<int, int>();
            foreach (var coin in set)
            {
                memo.Add(coin, 1);
            }
            return CheckCoinChange(amount, set, memo);
        }

        public int CheckCoinChange(int amount, HashSet<int> coins, Dictionary<int, int> memo)
        {
            if (amount == 0)
            {
                return 0;
            }
            if (memo.ContainsKey(amount))
            {
                return memo[amount];
            }
            foreach (var coin in coins)
            {

                if (coin <= amount)
                {
                    var newAmount = amount - coin;
                    var newAmountCointCount = CheckCoinChange(newAmount, coins, memo);
                    if (newAmountCointCount != -1)
                    {
                        if (!memo.ContainsKey(amount))
                        {
                            memo.Add(amount, int.MaxValue);
                        }
                        memo[amount] = Math.Min(newAmountCointCount + 1, memo[amount]);
                    }
                }

            }
            if (!memo.ContainsKey(amount))
            {
                memo.Add(amount, -1);
            }
            return memo[amount];
        }
    }
}