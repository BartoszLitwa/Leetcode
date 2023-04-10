public class Solution {
    public int RomanToInt(string s) {
        var roman = new Dictionary<char, int>{
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000} 
        };

        int res = 0;
        for(int i = 0; i < s.Length; i++){
            if(i + 1 < s.Length && roman[s[i]] < roman[s[i + 1]]){ // if next char is larger, then minus current char
                res -= roman[s[i]];
            } else { // if next char is smaller or equal, then plus current char
                res += roman[s[i]];
            }
        }

        return res;
    }
}