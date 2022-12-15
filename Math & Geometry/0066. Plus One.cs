public class Solution {
    public int[] PlusOne(int[] digits) {
        for(int i = digits.Length - 1; i >= 0; i--){
            if(digits[i] < 9){ // We only want to increment the digits that are smaller than 9
                digits[i]++;
                return digits;
            }
            // else set it to 0 and it will be incremented in the next loop
            digits[i] = 0;
        }
        // Edge case everything is 999
        var res = new int[digits.Length + 1];
        res[0] = 1;
        return res;
    }
}