public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var res = ""; // result

        for(int i = 0; i < strs[0].Length; i++){ // iterate through each character of the first string
            for(int j = 1; j < strs.Length; j++) { // iterate through each string
                // if the current character is not the same or the current string is shorter than the first string
                if(strs[j].Length == i || strs[0][i] != strs[j][i])
                    return res; // return the result
            }
            res += strs[0][i]; // add the current character to the result
        }

        return res;
    }
}