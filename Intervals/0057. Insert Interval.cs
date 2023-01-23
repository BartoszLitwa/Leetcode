public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var res = new List<int[]>();

        for(int i = 0; i < intervals.Length; i++){
            if(intervals[i][1] < newInterval[0]){ // start of the new interval is greater
                res.Add(intervals[i]); // Add the current interval to the list
            } else if(intervals[i][0] > newInterval[1]) { // end of the new intervals is smaller
                res.Add(newInterval); // Add the new interval
                res.AddRange(intervals[i..]); // Add all left intervals
                return res.ToArray();
            } else { // Merge
            // Do not add it yet since we do not know if we will have to merge multiple intervals
                newInterval = new int[2] { 
                    Math.Min(newInterval[0], intervals[i][0]),
                    Math.Max(newInterval[1], intervals[i][1]) }; 
            }
        }
        // Make sure we add it to the list 
        res.Add(newInterval);

        return res.ToArray();
    }
}