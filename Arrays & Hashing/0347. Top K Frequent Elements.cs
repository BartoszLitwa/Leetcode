public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var hashMap = new Dictionary<int, int>(); // Key - digit, Value - number of occurrences
        var freq = new List<int>[nums.Length + 1]; // Bucket sort Frequency Map
        
        // Count the occurencies of each digit
        for(int i = 0; i < nums.Length; i++){
            if(hashMap.ContainsKey(nums[i])){
                hashMap[nums[i]]++;
            } else {
                hashMap.Add(nums[i], 1);
            }
            // hashMap.TryAdd(nums[i], hashMap.TryGetValue(nums[i], out 0) + 1);
        }
        
        // Add to our bucket sor frequency map for each number of occurrences the digit
        foreach(var key in hashMap.Keys){
            var number = hashMap[key];
            if(freq[number] == null){
                freq[number] = new List<int>();
            }
            
            freq[number].Add(key);
            // Console.WriteLine($"freq[{number}].Add({key})");
        }
        
        var res = new List<int>();
        // Get the most frequent appearing digit
        for(int i = freq.Length - 1; i >= 0; i--){
            if(freq[i] == null)
                continue;
            
            // Console.WriteLine($"freq[{i}].Count = {freq[i].Count}");
            for(int f = 0; f < freq[i].Count; f++){
                res.Add(freq[i][f]);
                // Console.WriteLine($"res.Add({freq[i][f]});");
                
                if(res.Count == k)
                    return res.ToArray();
            }
        }
        
        return res.ToArray();
    }
}