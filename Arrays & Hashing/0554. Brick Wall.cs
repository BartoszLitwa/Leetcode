public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        int max = 0;
        
        foreach (var row in wall)
        {
            int sum = 0;
            for (int c = 0; c < row.Count - 1; c++)
            {
                sum += row[c];
                if (!map.ContainsKey(sum))
                {
                    map[sum] = 0;
                }
                map[sum]++;
                
                max = Math.Max(max, map[sum]);
            }
        }
        
        return wall.Count - max;
    }
}