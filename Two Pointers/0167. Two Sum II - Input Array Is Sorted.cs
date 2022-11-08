public class Solution {
    public int[] TwoSum(int[] numbers, int target){
        var dict = new Dictionary<int, int>(); // Key - number, value - index
        for(int i = 0; i < numbers.Length; i++){
            var val = target - numbers[i];
            if(dict.ContainsKey(val)) // If dict already seen this value that we are looking for
                return new int[] {dict[val] + 1, i + 1};
            
            if(!dict.ContainsKey(numbers[i])) // Prevent duplicates
                dict.Add(numbers[i], i); // Add the value to dict
        }
        
        return new int[] {0, 0};
    }
    
    public int[] TwoSum2(int[] numbers, int target) {
        int left = 0, right = numbers.Length - 1;
        while(left < right){
            if(numbers[left] + numbers[right] == target){ // If value is found
                return new int[] {++left, ++right};
            } else if(numbers[left] + numbers[right] < target){ // If target value is bigger
                left++; // Increase left index
            } else { // If target value is lower
                right--; // Decrease right index
            }
        }
        
        return new int[] {0, 0};
    }
}