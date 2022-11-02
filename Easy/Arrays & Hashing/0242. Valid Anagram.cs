public class Solution {
    public bool IsAnagram(string s, string t) {
        var letters = new char['z' - 'a' + 1];
        for(int i = 0; i < s.Length || i < t.Length; i++){
            if(i < s.Length)
                letters[s[i] - 'a']++;
            if(i < t.Length)
                letters[t[i] - 'a']--;
        }
        
        for(int i = 0; i < letters.Length; i++){
            if(letters[i] != 0) // If any letter is missing 
                return false;
        }
        return true;
    }
}