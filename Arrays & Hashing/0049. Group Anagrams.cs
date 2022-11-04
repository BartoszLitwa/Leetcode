public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var res = new Dictionary<string, IList<string>>();
        
        foreach (var str in strs){
            var charArray = str.ToArray();
            Array.Sort(charArray);
            var sorted = new String(charArray); // Sort alphabeticaly
            
            if(res.ContainsKey(sorted)){
                res[sorted].Add(str);
            } else {
                var newList = new List<string>();
                newList.Add(str);
                res.Add(sorted, newList);
            }
        }
        
        return res.Values.ToList();
    }
}