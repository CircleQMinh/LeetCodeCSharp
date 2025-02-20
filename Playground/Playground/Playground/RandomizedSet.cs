public class RandomizedSet
{
    private static Random random = new Random();
    public HashSet<int> Set { get; set;}
    public RandomizedSet()
    {
        Set = new HashSet<int>();
    }

    public bool Insert(int val)
    {
        return Set.Add(val);
    }

    public bool Remove(int val)
    {
        return Set.Remove(val);
    }

    public int GetRandom()
    {
        //if (Set == null || Set.Count == 0)
        //{
        //    throw new InvalidOperationException("HashSet is empty or null.");
        //}

        int index = random.Next(Set.Count);
        foreach (var item in Set)
        {
            if (index-- == 0)
            {
                return item;
            }
        }
        return 0;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */