public class Solution {
    public uint reverseBits(uint n) {
        uint res = 0;
        int count = 0;
        for(count = 0; n != 0; count++){
            res <<= 1; // Shift it to the left
            res |= (n & 1); // Add the last bit of n
            n >>= 1; // shift it right to remove used last bit
        }
        // Add the missing 0 at the end
        res <<= 32 - count;

        return res;
    }
}