public class Solution {
    public int[] CountBits(int n) {
        var res = new int[n + 1];
        res[0] = 0; // 0 has 0 bits of 1
        for(int i = 1; i <= n; i++){ // Iterate from 1 to n
            // If i is even, then it has the same number of 1 bits as i / 2.
            res[i] = res[i / 2] + (i & 1);
        }
        return res;
    }
}