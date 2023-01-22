public class Solution {
    public bool CheckValidString(string s) {
        int leftMin = 0, leftMax = 0;

        for(int i = 0; i < s.Length; i++){
            if(s[i] == '('){
                ++leftMin;
                ++leftMax;
            } else if(s[i] == ')'){
                --leftMin;
                --leftMax;
            } else { // *
                leftMin--; // We choose )
                leftMax++; // We choose (
            }
            if(leftMax < 0){ // There is always going to be more )
                return false;
            } else if(leftMin < 0){ // When we dip below 0 reset it to 0
                leftMin = 0; // We cannot have negative number of ( paranthesis
            }
        }

        return leftMin == 0; // We have to have every bracket closes
    }
}