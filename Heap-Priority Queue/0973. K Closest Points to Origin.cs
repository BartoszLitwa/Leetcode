public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var list = new SortedList<double, IList<int[]>>();
        for(int i = 0; i < points.Length; i++){
            var dist = (Math.Pow(0 - points[i][0], 2) + Math.Pow(0 - points[i][1], 2));

            if(list.ContainsKey(dist)){
                list[dist].Add(points[i]);
            } else {
                list.Add(dist, new List<int[]>{points[i]});
            }
        }

        var res = new List<int[]>();
        int index = 0;
        for(int i = 0; i < list.Count && index < k; i++){
            foreach(var p in list[list.Keys[i]]){
                if(index++ < k)
                    res.Add(p);
            }
        }
        return res.ToArray();
    }
}