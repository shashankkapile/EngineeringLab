public class RandomizedSet {
    Dictionary<int, int> map;
    List<int> list;
    Random rnd;

    public RandomizedSet() {
        map = new Dictionary<int, int>();
        list = new List<int>();
        rnd = new Random();
    }

    public bool Insert(int val) {
        if (map.ContainsKey(val)) return false;
        map[val] = list.Count;
        list.Add(val);
        return true;
    }

    public bool Remove(int val) {
        if (!map.ContainsKey(val)) return false;

        int idx = map[val];
        int lastVal = list[list.Count - 1];

        // Swap with last element
        list[idx] = lastVal;
        map[lastVal] = idx;

        // Remove last
        list.RemoveAt(list.Count - 1);
        map.Remove(val);

        return true;
    }

    public int GetRandom() {
        int idx = rnd.Next(list.Count);
        return list[idx];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */