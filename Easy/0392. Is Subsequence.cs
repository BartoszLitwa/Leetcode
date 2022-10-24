public class Solution {
    public bool IsSubsequence(string s, string t) {
        int curS = 0;
        
        for(int i = 0; i < t.Length && curS < s.Length; i++){
            if(s[curS] == t[i]){
                curS++;
            }
        }
        
        return curS == s.Length;
    }
    
    public bool IsSubsequence2(string s, string t) {
        if(s.Length == 0){
            return true;
        }
        
        int curS = 0;
        for(int i = 0; i < t.Length; i++){
            if(s[curS] == t[i]){
                curS++;
                
                if(curS == s.Length){
                    return true;
                }
            }
        }
        
        return false;
    }
}