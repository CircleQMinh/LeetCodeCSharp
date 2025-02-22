using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhVu
{
    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            var startLocation = -1;
            var n = gas.Length;
            if (n < 2)
            {
                return gas[0] >= cost[0] ? 0 : -1;
            }
            for (int i = 0; i < n; i++)
            {
                var index = i % n;
                if (gas[index] > cost[index])
                {
                    startLocation = index;
                    if (TryCompleCircuit(gas, cost, startLocation))
                    {
                        return startLocation;
                    }
                }
            }
            return -1;
        }
        public bool TryCompleCircuit(int[] gas, int[] cost, int start)
        {
            var n = gas.Length;
            var tank = 0;
            for (int i = 0; i < n; i++)
            {
                var index = (start + i) % n;
                tank += gas[index];
                if (tank < cost[index])
                {
                    return false;
                }
                tank -= cost[index];

            }
            return true;
        }
    }
}