public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        var res = new List<string>();
        if(s.Length > 12) // Valid IP Address can not have more than 12 digits
            return res; // Empty

        Backtrack(0, 0, "");

        return res;

        void Backtrack(int i, int dots, string curIP){
            if(dots == 4 && i == s.Length){ // Found a valid IP
                res.Add(curIP[0..(curIP.Length - 1)]); // Remove the last dot
                return;
            }
            if(dots > 4) // Max 4 dots
                return;

            for(int j = i; j < Math.Min(i + 3, s.Length); j++){
                var digit = Int32.Parse(s[i..(j + 1)]); // Parse the current substring - octect of IP
                // In bounds and not starting with 0 digit or is a single digit
                if(digit < 256 && (s[i] != '0' || i == j)) // Valid octect
                    Backtrack(j + 1, dots + 1, curIP + $"{digit}.");
            }
        }
    }
}