public class Solution {
    // Binet's Nth-term Formula
    // Using approximation equation is good enough here, since we know N >= 0 && N <= 30,
    // we can safely use the following rounded function
    // Phi = ( sqrt(5) + 1 ) / 2
    // Fib(N) = round( ( Phi^N ) / sqrt(5) )
    public int Fib(int n) {
        var phi = (Math.Sqrt(5) + 1) / 2;
        return (int)Math.Round(Math.Pow(phi, n) / Math.Sqrt(5));
    }
    
    // Imperative Approach
    public int Fib2(int n){
        if(n < 2)
            return n;
        
        int cur = 1, prev = 1, pprev = 0;
        for(int i = 2; i <= n; i++){
            // Add 2 previous values
            cur = prev + pprev;
            // Switch the prev to current and pprev to prev
            pprev = prev;
            prev = cur;
        }
        
        return cur;
    }
    
    // Dynamic Programming approach
    public int Fib3(int n) {
        if(n < 2)
            return n;
        
        var fib = new int[n + 1];
        fib[0] = 0;
        fib[1] = 1;
        for(int i = 2; i <= n; i++){
            fib[i] = fib[i - 1] + fib[i - 2];
        }
        
        return fib[n];
    }
    
    // Recursive
    public int Fib4(int n) {
        return helper(n);
    }
    
    private int helper(int n){
        return n == 0 ? 0 : n <= 2 ? 1 : helper(n - 1) + helper(n - 2);
    }
}