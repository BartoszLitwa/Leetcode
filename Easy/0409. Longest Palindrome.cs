public class Solution {
    public int LongestPalindrome(string s) {
        int odds = 0;
        // Count how many of odd chars are in string
        for (char c='A'; c<='z'; c++){
            if(s.Contains(c))
            // Bit And Operator checking for last bit - returns 0 or 1
                odds += s.Count(x => x == c) & 1;
        }
        
        // String length - odds characters + 1 if we have more than 0 of them
        return s.Length - odds + (odds > 0 ? 1 : 0);
    }
    
    public int LongestPalindrome2(string s) {
        var dict = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++){
            if(!dict.ContainsKey(s[i])){
                dict.Add(s[i], 1);
            } else {
                dict[s[i]] += 1;
            }
        }
        
        int counter = 0, odd = 0;
        foreach(var val in dict.Values.ToList()){
            if(val % 2 == 0)
                counter += val;
            else if (val > 1){
                counter += val - 1;
                odd++;
            } else {
                odd++;
            }
        }
        
        return counter + (odd > 0 ? 1 : 0);
    }
}