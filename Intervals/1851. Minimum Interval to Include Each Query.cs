public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        intervals = intervals.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
        var queryIndices = new Dictionary<int, List<int>>();
        for (int i = 0; i < queries.Length; i++) { // Map each query to its index
            if (!queryIndices.ContainsKey(queries[i])) {
                queryIndices[queries[i]] = new List<int>();
            }
            queryIndices[queries[i]].Add(i);
        }
        var sortedQueries = queries.OrderBy(x => x).ToList();
        var res = new int[queries.Length];

        int index = 0;
        var minHeap = new SortedDictionary<int, SortedSet<int>>();
        foreach (var q in sortedQueries) {
            // Add all intervals that start before or at q
            while (index < intervals.Length && intervals[index][0] <= q) {
                int size = intervals[index][1] - intervals[index][0] + 1;
                if (minHeap.ContainsKey(size)) {
                    minHeap[size].Add(intervals[index][1]);
                } else {
                    minHeap.Add(size, new SortedSet<int> { intervals[index][1] });
                }
                index++;
            }
            // Remove all intervals that end before q
            while (minHeap.Count > 0 && minHeap.First().Value.Min() < q) {
                var val = minHeap.First().Value;
                val.Remove(val.Min());
                if (val.Count == 0) {
                    minHeap.Remove(minHeap.First().Key);
                }
            }

            if (queryIndices.ContainsKey(q)) { // Map the query to the answer
                int ans = minHeap.Count == 0 ? -1 : minHeap.First().Key;
                foreach (var indexInQueries in queryIndices[q]) {
                    res[indexInQueries] = ans;
                }
            }
        }

        return res;
    }
}