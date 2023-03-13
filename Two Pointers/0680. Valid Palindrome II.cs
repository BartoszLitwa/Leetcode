public class Solution {
    public bool ValidPalindrome(string s) {
        int start = 0, end = s.Length - 1;
        
        while(start < end){ // Loop until start and end meet
            if(s[start++] != s[end--]){ // If not equal
                return ValidPalindromeHelper(start, end + 1)  // Check if valid palindrome if we skip start
                    || ValidPalindromeHelper(start - 1, end); // Check if valid palindrome if we skip end
            }
        }

        return true;

        bool ValidPalindromeHelper(int start, int end){
            while(start < end){
                if(s[start++] != s[end--]){
                    return false;
                }
            }

            return true;
        }
    }
}