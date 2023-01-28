public class Solution {
    public double MyPow(double x, int n) {
        long p = (long) n; 
        
        if(p < 0 ) 
        {
            p = -p;
            x = 1 / x;
        }
        
        double result = 1;
        while(p > 0) // x^13 = x^8 * x^4 * x^1   13 = (1101) in binary
        {
            if(p % 2 == 1) 
                result = result * x;
            x = x * x;
            p = p / 2;
        }
        
        return result;
    }
}