public class Solution {
    // Its the same as Fibnoachi
    // From step n - 1 to n we can take 1 step and from n - 2 we can take 2 steps
    public int ClimbStairs(int n) {
        if(n < 3)
            return n;
        
        int pprev = 1, prev = 1, cur = pprev + prev;
        for(int i = 2; i <= n; i++){
            cur = pprev + prev;
            pprev = prev;
            prev = cur;
        }
        
        return cur;
    }
}