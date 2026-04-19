// https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/803/
public class Solution {
    public int[][] Merge(int[][] intervals) {

        // #1 brute force 
        // #2 optimal
        // #3 optimal with current
        
         //sort by start time
        Array.Sort(intervals, (A, B) => A[0].CompareTo(B[0])); 
        var result = new List<int[]>();
        
        var current = intervals[0];
        foreach(var interval in intervals)
        {
            if (current[1] >= interval[0])
            {
                 //overlapping, so merge but pick largest end
                current[1] = Math.Max(interval[1], current[1]);
            }
            else
            {
               //non overlapping
                result.Add(current);
                current = interval;
            }
        }

        result.Add(current);
        return result.ToArray();
    }
}