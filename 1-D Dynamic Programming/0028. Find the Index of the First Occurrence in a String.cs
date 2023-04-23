public class Solution {
    public int StrStr(string haystack, string needle) {
        if(needle == "")
            return 0;

        // Check only up to last possible index that needle can be found in haystack
        for(int i = 0; i <= haystack.Length - needle.Length; i++){ 
            if(haystack[i..(i + needle.Length)] == needle) // Found needle
                return i;
        }

        return -1;
    }
}