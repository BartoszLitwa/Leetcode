public class Solution {
    public IList<int> PartitionLabels(string s) {
        var map = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++){ // Map the last occurance of char in string
            if(!map.ContainsKey(s[i])){
                map.Add(s[i], i);
            } else { // We could skip the comparison part
                map[s[i]] = Math.Max(map[s[i]], i);
            }
        }

        int end = 0, size = 0;
        var res = new List<int>();
        for(int i = 0; i < s.Length; i++){
            size++; // Increment the current partion size
            // Update the index our partion ends
            end = Math.Max(end, map[s[i]]);

            if(end == i){ // We reached our partion end
                res.Add(size);
                size = 0; // Reset size of current partion
            }
        }

        return res;
    }
}