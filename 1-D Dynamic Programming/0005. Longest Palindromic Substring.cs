public class Solution {
    public string LongestPalindrome(string s) {
        string res = "";

        for(int i = 0; i < s.Length; i++){
            int l = i, r = i;
            // Check for odd case - "tt"
            res = Pali(l, r, s, res);
            // Check for even case - "tbt"
            l = i;
            r = i + 1;
            res = Pali(l, r, s, res);
        }

        return res;
    }

    private string Pali(int l, int r, string s, string res){
        while(l >= 0 && r < s.Length && s[l] == s[r]){
            if(r - l + 1 > res.Length){
                res = s.Substring(l, r - l + 1);
            }
            l--;
            r++;
        }

        return res;
    }
}