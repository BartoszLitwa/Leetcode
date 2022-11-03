public class Solution {
    // Sliding window approach O(n) - BETTER 
    public int CharacterReplacement(string s, int k) {
        var charCount = new char['Z' - 'A' + 1];
        int  res = 0;
        
        int max = 0;
        int left = 0, right = 0;
        while(right < s.Length){
            // Increment the value of right edge and store it
            // If its the max freq
            max = Math.Max(max, ++charCount[s[right] - 'A']);
            
            while((right - left + 1 - max) > k){
                // Decrement the value of left edge
                charCount[s[left++] - 'A']--;
            }
            
            // Set the current longest substring
            // right - left - 1 - length of our sliding window - max freq
            res = Math.Max(res, right - left + 1);
            // Increment the right edge of the window at the end
            right++;
        }
        
        return res;
    }
    
    // Sliding window approach O(26 * n)
    public int CharacterReplacement2(string s, int k) {
        var charCount = new char['Z' - 'A' + 1];
        int  res = 0;
        
        int left = 0, right = 0;
        while(right < s.Length){
            // Increment the value of right edge
            charCount[s[right] - 'A']++;
            
            int max = 0;
            // Get the max freq char in our hash table
            for(int i = 0; i < charCount.Length; i++){
                if(charCount[i] > max){
                    max = charCount[i];
                }
            }
            
            while((right - left + 1 - max) > k){
                // Decrement the value of left edge
                charCount[s[left++] - 'A']--;
            }
            
            // Set the current longest substring
            // right - left - 1 - length of our sliding window - max freq
            res = Math.Max(res, right - left + 1);
            // Increment the right edge of the window at the end
            right++;
        }
        
        return res;
    }
}