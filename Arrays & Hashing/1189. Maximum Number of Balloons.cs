public class Solution {
    public int MaxNumberOfBalloons(string text) {
        var textHash = new Dictionary<char, int>();
        var balloonHash = new Dictionary<char, int>();

        foreach(var c in "balloon"){ // Map the balloon's characters
            if(balloonHash.ContainsKey(c))
                balloonHash[c]++;
            else
                balloonHash.Add(c, 1);
        }

        foreach(var c in text){ // Map the text's characters
            if(textHash.ContainsKey(c))
                textHash[c]++;
            else
                textHash.Add(c, 1);
        }

        var res = text.Length; // The maximum number of balloons is the length of the text
        foreach(var key in balloonHash.Keys){ // Check if the text contains all the characters of the balloon
            if(textHash.ContainsKey(key)) // If it does, check if the number of characters is enough to form a balloon
                res = Math.Min(res, textHash[key] / balloonHash[key]);
            else // If it doesn't, the maximum number of balloons is 0
                return 0;
        }
        return res;
    }
}