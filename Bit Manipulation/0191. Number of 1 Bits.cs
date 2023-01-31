public class Solution {
    public int HammingWeight(uint n) {
        return n == 0 ? 0 : (int)(n & 1) + HammingWeight(n >> 1);
    }

    public int HammingWeight2(uint n) {
        int res = 0;
        while(n != 0){
            if((n & 1) == 1)
                res++;
            n >>= 1;
        }
        return res;
    }
}