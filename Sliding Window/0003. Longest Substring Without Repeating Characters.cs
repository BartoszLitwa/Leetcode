public class Solution {
    public int LengthOfLongestSubstring(string s){
        int left = 0, right = 0, max = 0;
        var hashSet = new HashSet<char>();
        while(right < s.Length){
            if(!hashSet.Contains(s[right])){
                hashSet.Add(s[right++]); // Add the value and increment right
                max = Math.Max(max, hashSet.Count); // Set possible max value - Unique letters
            } else {
                hashSet.Remove(s[left++]); // Remove the left letter and increment left pointer
            }
        }
        
        return max;
    }
    
    public int LengthOfLongestSubstring2(string s) {
        var hashSet = new HashSet<char>();
        
        int left = 0, max = 0;
        for(int right = 0; right < s.Length; right++){
            while(hashSet.Contains(s[right])){ // Current right edge letter already in the hashset
                hashSet.Remove(s[left]); // Remove left edge letter
                left++; // Increment left edge of the window
            }
            
            // Set possible max value
            max = Math.Max(max, right - left + 1);
            
            // Add current right edge letter
            hashSet.Add(s[right]);
        }
        
        return max;
    }
}