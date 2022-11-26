public class Solution {
    public bool IsPalindrome(int x) {
        if (x<0 || (x !=0 && x % 10 == 0))
            return false;
        
        int rev = 0;
        while (x>rev){ // Check only the half
            rev *= 10; //Multiply the prev res by 10 to move it to left by 1
            rev += x % 10; // add the remaining value of reversed integer
            x /= 10;
        }
        
        return (x == rev || x == rev / 10);
    }
}