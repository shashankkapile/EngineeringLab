// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/799/

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        // #1 max heap
        // return MaxHeapBetter(nums, k);
        
        // #2 min heap
        return MinHeapOptimal(nums, k);
    }

    private int[] MinHeapOptimal(int[] nums, int k)
    {
        var minHeap = new PriorityQueue<int, int>();
        var map = new Dictionary<int, int>();
        foreach(var num in nums)
        {
            if(map.ContainsKey(num)) map[num]++;
            else map.Add(num, 1);
        }

        foreach(var pair in map)
        {
            minHeap.Enqueue(pair.Key, pair.Value);
            
            //min heap contains least frequent at top, so remove top non required items
            if(minHeap.Count>k){
                minHeap.Dequeue();
            }
            
        }

        var result = new List<int>();
        while (k > 0 && minHeap.Count>0)
        {
            result.Add(minHeap.Dequeue());
            k--;
        }
        return result.ToArray();
    }
    
    private int[] MaxHeapBetter(int[] nums, int k)
    {
        var maxHeap = new PriorityQueue<int, int>();
        var map = new Dictionary<int, int>();
        foreach(var num in nums)
        {
            if(map.ContainsKey(num)) map[num]++;
            else map.Add(num, 1);
        }

        foreach(var pair in map)
        {
            maxHeap.Enqueue(pair.Key, -pair.Value);
        }

        var result = new List<int>();
        while (k > 0 && maxHeap.Count>0)
        {
            result.Add(maxHeap.Dequeue());
            k--;
        }
        return result.ToArray();
    }
}