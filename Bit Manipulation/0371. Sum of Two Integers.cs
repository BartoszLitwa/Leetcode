public class Solution {
    public int GetSum(int a, int b) {
        while(b != 0) // While there is a carry
        {
            int carry = a & b; // Get the carry
            a = a ^ b; // Add the bits
            b = carry << 1; // Shift the carry to the left
        }        
        return a;
    }
}