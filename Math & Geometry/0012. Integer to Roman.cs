public class Solution {
    public string IntToRoman(int num) {
        // Map the values to the strings
        int[] values = {1000,900,500,400,100,90,50,40,10,9,5,4,1};
        String[] strs = {"M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};
        
        var sb = new StringBuilder();
        int index = 0; // Index of the current value
        while(num != 0){ // While there is still a remainder
            while(num >= values[index]){ 
                num -= values[index];
                sb.Append(strs[index]);
            }
            index++; // Move to the next value
        }
        return sb.ToString();
    }
}