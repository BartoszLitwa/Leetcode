public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        var dir = new Dictionary<char, int>();
        int index = 0;
        foreach(var c in order){ // Create a dictionary to store the order of the characters
            dir.Add(c, index++);
        }

        for(int i = 0; i < words.Length - 1; i++){
            string w1 = words[i], w2 = words[i + 1];

            for(int j = 0; j < w1.Length; j++){
                if(j == w2.Length) // Make sure the left word is shorter
                    return false;

                if(w1[j] == w2[j]) // Skip if the same
                    continue;

                if(dir[w1[j]] > dir[w2[j]]){ // If the left character is later in the order, then return false
                    return false;
                }

                break; // If the left character is earlier in the order, then break - ok
            }
        }

        return true;
    }
}