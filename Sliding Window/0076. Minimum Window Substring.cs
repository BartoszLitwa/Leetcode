public class Solution {
    public string MinWindow(string s, string t) {
        if(t == "") // Edge case
            return "";

        var tDict = new Dictionary<char, int>();
        foreach(var c in t){ // Build the dictionary
            if(tDict.ContainsKey(c))
                tDict[c]++;
            else
                tDict.Add(c, 1);
        }

        (int Left, int Right) res = (-1, -1); // The result window
        int resLen = Int32.MaxValue; // The length of the result window
        int matched = 0; // The number of matched characters
        var window = new Dictionary<char, int>(); // The sliding window
        int left = 0; // The left pointer of the sliding window
        for(int right = 0; right < s.Length; right++){ // The right pointer of the sliding window
            if(window.ContainsKey(s[right])) // Update the sliding window
                window[s[right]]++;
            else
                window.Add(s[right], 1);
            // Update the matched number
            if(tDict.ContainsKey(s[right]) && window[s[right]] == tDict[s[right]])
                matched++;

            while(matched == tDict.Count){ // Until it matches slide window's left pointer to the right
                if((right - left) < resLen){ // Update the result
                    resLen = (right - left); // Update the length of the result
                    res = (left, right + 1); // Update the result
                }
                // Update the sliding window
                if(tDict.ContainsKey(s[left]) && --window[s[left]] < tDict[s[left]])
                    matched--;
                // Slide the left pointer to the right
                left++;
            }
        }
        // Return the result only if it is not the default value
        return resLen != Int32.MaxValue ? s[res.Left..res.Right] : "";
    }
}