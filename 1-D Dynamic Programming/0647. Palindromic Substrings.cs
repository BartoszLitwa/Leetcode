public class Solution {
    private int res;

    public int CountSubstrings(string s) {
        res = 0;
        for(int i = 0; i < s.Length; i++){
            int l = i, r = i; // Odd case "tt"
            Substrings(l, r, s);

            l = i;
            r = i + 1; // Even case "tbt"
            Substrings(l, r, s);
        }
        
        return res;
    }

    private void Substrings(int l, int r, string s){
        while(l >= 0 && r < s.Length && s[l] == s[r]){
            res++;
            l--;
            r++;
        }
    }
}