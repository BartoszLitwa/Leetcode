public class Solution {
    // O(n) solution
    public string GetHint(string secret, string guess){
        int bulls = 0, cows = 0;
        var digits = new int[10]; // From 0 to 9
        
        for(int i = 0; i < secret.Length; i++){
            if(secret[i] == guess[i])
                bulls++;
            else {
                // It has to be 2 if statements
                // If the guess digit already appeared in secret 
                if(digits[secret[i] - '0']++ < 0) // Add the digit from secret if it appeared
                    cows++;
                // Or the secret digit already appedred in guess
                if(digits[guess[i] - '0']-- > 0) // Remove the digit from guess if it appeared
                    cows++;
            }
        }
        
        return $"{bulls}A{cows}B";
    }
    
    // Max O(2n)
    public string GetHint2(string secret, string guess) {
        int bull = 0, cow = 0;
        var s = new List<int>();
        var g = new List<int>();
        
        for(int i = 0; i < secret.Length; i++){
            if(secret[i] == guess[i]){
                bull++;
            } else { // Only add the cow digits
                s.Add(secret[i]);
                g.Add(guess[i]);
            }
        }
        
        int size = s.Count;
        for(int i = 0; i < size; i++){
            if(s.Contains(g[i])){ // If it contains that the value
                cow++; // Increase the cow counter
                s.Remove(g[i]); // removed the guessed digit ffrom secret
            }
        }
        
        return $"{bull}A{cow}B";
    }
}