public class Solution {
    // Dynamic Programming Approach
    public int UniquePaths(int m, int n){
        // m - row, n - col
        var tab = new int[m, n];
        
        // We are going from result to start
        for(int i = m - 1; i >= 0; i--){ // row
            for(int j = n - 1; j >= 0; j--){ // col
                if(i == m - 1 || j == n - 1) // last row or last col - always 1 possibility
                    tab[i, j] = 1;
                else // Current cell = cell on the right + cell below
                    tab[i, j] = tab[i + 1, j] + tab[i, j + 1];
            }
        }
        
        return tab[0, 0];
    }
    
    // Using combinations - order doesnt matter
    // a = m + n
    // C(a, n) = a! / (a - n)! * n!
    public int UniquePaths3(int m, int n) {
        if(m == 1 || n == 1){
            return 1;
        }
        
        m--;
        n--;
        return (int)Math.Round(Fact(m + n) / (Fact(m) * Fact(n)));
    }
        
    private double Fact(int m){
        double res = 1;
        for(int i = 2; i <= m; i++){
            res *= i;
        }
        
        return res;
    }
    
    public int UniquePaths2(int m, int n) {
        if(m == 1 || n == 1)
            return 1;
        m--;
        n--;
        if(m < n) {              // Swap, so that m is the bigger number
            m = m + n;
            n = m - n;
            m = m - n;
        }
        double res = 1;
        int j = 1;
        for(int i = m+1; i <= m+n; i++, j++){       // Instead of taking factorial, keep on multiply & divide
            res *= i;
            res /= j;
        }
            
        return (int)res;
    }
}