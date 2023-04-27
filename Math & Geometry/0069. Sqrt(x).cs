public class Solution {
    public int MySqrt(int x) {
        if (x <= 1) // 0 and 1 are special cases
            return x;
        int left = 1, right = x / 2; // x / 2 is the largest possible sqrt(x)
        while (left <= right) {
            int mid = left + (right - left) / 2;
            long pow = (long) mid * mid; // Prevent overflow
            if (pow == x) { // Found the sqrt(x)
                return mid;
            } else if (pow > x) { // Too big
                right = mid - 1;
            } else { // Too small
                left = mid + 1;
            }
        }
        return right;
    }
}