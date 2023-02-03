public class Solution {
    public int Reverse(int x) {
        int res = 0;
        int max = Int32.MaxValue / 10;
        int min = Int32.MinValue / 10;
        while(x != 0){ // While there is a digit
            var digit = x % 10; // Get the last digit
            x /= 10; // Remove the last digit

            if((res > max || (res == max && digit >= Int32.MaxValue % 10)) || // If the result is greater than the max
                (res < min || (res == min && digit <= Int32.MinValue % 10))) // If the result is less than the min
                return 0; // Return 0

            res = (10 * res) + digit; // Move the cur res to the left and add the digit
        }
        return res;
    }
}