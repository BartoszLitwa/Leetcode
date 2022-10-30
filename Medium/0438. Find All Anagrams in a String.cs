public class Solution {
    public IList<int> FindAnagrams(string s, string p){
        var res = new List<int>();
        
        if(s.Length == 0 || p.Length > s.Length)
            return res;
        
        var pCount = new int['z' - 'a' + 1];
        var sCount = new int['z' - 'a' + 1];
        for(int i = 0; i< p.Length; i++){
            pCount[p[i] - 'a']++;
            sCount[s[i] - 'a']++;
        }
        
        bool same = true;
        for(int i = 0; i < pCount.Length; i++){
            if(pCount[i] != sCount[i]){
                same = false;
                break;
            }
        }
        if(same) // If the same letters count add it to res
            res.Add(0); 
        
        for(int i = p.Length; i < s.Length; i++){
            sCount[s[i - p.Length] - 'a']--; // Left pointer, decrement frequency
            sCount[s[i] - 'a']++; // Right pointer, increment frequency
            
            bool sameWindow = true;
            for(int a = 0; a < pCount.Length; a++){
                if(pCount[a] != sCount[a]){
                    sameWindow = false;
                    break;
                }
            }
            if(sameWindow) // If the same letters count add it to res
                res.Add(i - p.Length + 1); // Add + 1 because we already decremented it
        }
        
        return res;
    }
    
    public IList<int> FindAnagrams2(string s, string p) {
        var res = new List<int>();
        
        if(s.Length == 0)
            return res;
        
        // Get the frequency array of the letters of p's anagram
        var charCount = new int['z'-'a' + 1]; // Equal to 26
        for(int i = 0; i < p.Length; i++){
            // Increment the char count
            charCount[p[i] - 'a']++;
        }
        
        int left = 0, right = 0, count = p.Length;
        // Sliding window The left and right end represent the end of a window
        // Count is the number of left chars to be found in the window
        while(right < s.Length){
            // If we found the letter decrease its char count
            if(charCount[s[right++] - 'a']-- >= 1)
                count--;
            
            // If the count left is 0 we found the anagram
            if(count == 0)
                res.Add(left);
            
            // If we already checked the right window length and increment previously
            // decremented char count of the letters in window
            if(right - left == p.Length && charCount[s[left++] - 'a']++ >= 0)
                count++;
        }
        
        return res;
    }
}