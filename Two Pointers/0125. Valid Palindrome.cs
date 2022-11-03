using System.Text.RegularExpressions;

public class Solution {
    public bool IsPalindrome(string s) {
        int left = 0, right = s.Length - 1;
        
        // Loop until left and right meet
        while(left < right){
            // If is not alpha check for next
            while(left < right && !IsAlpha(s[left])){
                left++;
            }
            
            // Make sure it stays within their bounds
            while(left < right && !IsAlpha(s[right])){
                right--;
            }
            
            // Increment left and decrement right pointer
            if(Char.ToLower(s[left++]) != Char.ToLower(s[right--]))
                return false;
        }
        
        return true;
    }
    
    public bool IsAlpha(char c){
        return ('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z') || ('0' <= c && c <= '9');
    }
    
    public bool IsPalindrome2(string s) {
        // Remove all non alphanumeric characters
        var res = Regex.Replace(s.ToLower(), "[^a-zA-Z0-9]", String.Empty);
        for(int i = 0; i < res.Length / 2; i++){
            if(res[i] != res[res.Length - 1 - i])
                return false;
        }
        
        return true;
    }
}