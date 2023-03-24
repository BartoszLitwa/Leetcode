public class Solution {
    public bool IsPerfectSquare(int num) {
        int left = 1, right = num;
        while(left <= right){
            var mid = (left + right) >> 1;
            var res = Math.Pow(mid, 2); // Multiply mid by itself
            if(res == num) // Found
                return true;
            else if(res > num) // Too big
                right = mid - 1;
            else // Too small
                left = mid + 1;
        }
        return false; // Not found
    }
}