public class Solution {
    public int ArrangeCoins(int n) {
        int left = 1, right = n;
        int res = 0;
        while(left <= right){
            // Cant use (left + right) / 2, because it will overflow
            int midPoint = left + (right - left) / 2; 
            // It has to be double, otherwise it will overflow
            double coinsInMidsRow = (midPoint / 2d) * (midPoint + 1d); // Gauss sum
            if(coinsInMidsRow > n)
                right = midPoint - 1;
            else {
                left = midPoint + 1;
                res = Math.Max(res, midPoint);
            }
        }
        return res;
    }
}