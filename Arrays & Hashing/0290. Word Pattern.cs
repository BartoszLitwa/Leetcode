public class Solution {
    public bool WordPattern(string pattern, string s) {
        var split = s.Split(" ");
        if(split.Length != pattern.Length) // if the length of the pattern and the string are not equal
            return false;

        var charToWord = new Dictionary<char, string>();
        var wordToChar = new Dictionary<string, char>();
        for(int i = 0; i < split.Length; i++){
            if((charToWord.TryGetValue(pattern[i], out var word) && word != split[i]) || // if the current letter is already mapped to a different word
                (wordToChar.TryGetValue(split[i], out var letter) && letter != pattern[i])) // if the current word is already mapped to a different letter
                return false;
            // Map/Remap letter to word and world to letter
            charToWord[pattern[i]] = split[i];
            wordToChar[split[i]] = pattern[i];
        }

        return true;
    }
}