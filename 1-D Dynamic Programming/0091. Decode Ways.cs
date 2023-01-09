public class Solution {
    private string word;
    private Dictionary<int, int> cached;
    public int NumDecodings(string s) {
        word = s;
        cached = new Dictionary<int, int>{
            { s.Length, 1 } // Cash last result as 1 so we could return it
        };

        return DFS(0);
    }

    private int DFS(int i){
        if(cached.ContainsKey(i)) // Check if it is cached
            return cached[i];
        if(word[i] == '0') // We cannot decode 0
            return 0;
        
        int res = DFS(i + 1); // Continue checking for next digit
        if(i + 1 < word.Length && (word[i] == '1' || // Starts with 1 we can accept it
            (word[i] == '2' && word[i + 1] >= '0' && word[i + 1] <= '6'))) // starting with 2 it has to be 20-26
            res += DFS(i + 2); // Possibility that it could be 2 digit number

        cached.Add(i, res);
        return res; // Return result
    }
}

// Iterative approach
public class Solution {
    public int NumDecodings(string word) {
        var cached = new Dictionary<int, int>{
            { word.Length, 1 } // Cash last result as 1 so we could return it
        };

        for(int i = word.Length - 1; i >= 0; i--){
            if(word[i] == '0')
                cached[i] = 0;
            else
                cached.Add(i, cached[i + 1]);

            if(i + 1 < word.Length && (word[i] == '1' || // Starts with 1 we can accept it
                (word[i] == '2' && word[i + 1] >= '0' && word[i + 1] <= '6'))) // starting with 2 it has to be 20-26
                cached[i] += cached[i + 2]; // Possibility that it could be 2 digit number
        }

        return cached[0];
    }
}