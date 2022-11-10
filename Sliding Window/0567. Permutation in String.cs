public class Solution {
    // O(26) + O(n) = O(n)
    // Simpler version would at each loop check equity of the hashamps which would increase to O(26n)
    public bool CheckInclusion(string s1, string s2) {
        if(s2.Length < s1.Length)
            return false;
        
        var chars1 = new char['z' - 'a' + 1];
        var chars2 = new char['z' - 'a' + 1];
        
        // Enumerate the possible first permutation in s2 of s1
        for(int i = 0; i < s1.Length; i++){
            chars1[s1[i] - 'a']++;
            chars2[s2[i] - 'a']++;
        }
        
        var matches = 0;
        for(int i = 0; i < chars1.Length; i++){
            if(chars1[i] == chars2[i]) // Increment only if value of each letter is the same
                matches++;
        }
        
        //Sliding window
        for(int i = s1.Length; i < s2.Length; i++){
            if(matches == chars2.Length) // We found the permutation
                return true;
            
            var indRight = s2[i] - 'a';
            if(++chars2[indRight] == chars1[indRight]) // if incremented right window letter is equal
                matches++;
            else if(chars2[indRight] == chars1[indRight] + 1) // It was previously equal but it isnt
                matches--;
            
            var indLeft = s2[i - s1.Length] - 'a';
            if(--chars2[indLeft] == chars1[indLeft]) // if decremented left window letter is equal
                matches++;
            else if(chars2[indLeft] == chars1[indLeft] - 1) // It was previously equal but it isnt
                matches--;
        }
        
        return matches == chars2.Length; // Important to check after last loop if its equal
    }
}