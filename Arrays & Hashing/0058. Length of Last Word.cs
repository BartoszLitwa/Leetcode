public class Solution {
    public int LengthOfLastWord(string s) {
        // Split the string by spaces and remove empty strings
        var split = s.Split(' ').Where(x => !string.IsNullOrEmpty(x));
        return split.Last().Length; // Return the length of the last string
    }
}