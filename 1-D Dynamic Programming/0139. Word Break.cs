public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        var cached = new bool[s.Length + 1];
        cached[s.Length] = true; // Set that when we reach the end of s its true

        for(int i = 0; i < s.Length; i++){
            cached[i] = false;
        }

        // Start bottom to top
        for(int i = s.Length - 1; i >= 0; i--){
            for(int w = 0; w < wordDict.Count; w++){
                if(i + wordDict[w].Length <= s.Length){ // If the length is in bound
                    int temp = i;
                    foreach(var c in wordDict[w]){
                        if(s[temp] != c) // SubWord is different
                            break;
                        temp++;
                    }
                    // Set the current res to the result of previous
                    if(temp == i + wordDict[w].Length) // Only if we reached the end
                        cached[i] = cached[i + wordDict[w].Length];
                }

                if(cached[i]) // If true - we know that up to this point it is doable
                    break; // Break out of this loop
            }
        }

        return cached[0];
    }
}