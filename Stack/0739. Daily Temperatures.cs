public class Solution {
    // O(n) and O(1) space
    public int[] DailyTemperatures(int[] temperatures) {
        var res = new int[temperatures.Length];
        
        // Compute in reverse order
        for(int i = temperatures.Length - 1; i >= 0; i--){
            int j = i + 1; // Start at the next elem
            // Only search for j in the bounds until temp on j-th day is lower than current
            while(j < temperatures.Length && temperatures[j] <= temperatures[i]){
                if(res[j] > 0) // If we found the day that will have higher temp in the future
                    j += res[j]; // add the days
                else // We couldnt find
                    j = temperatures.Length; // set the j = size to break the while loop
            }
            
            if(j < temperatures.Length) // If we found it just set the days
                res[i] = j - i;
        }
        
        return res.ToArray();
    }
    
    // O(n)
    public int[] DailyTemperatures2(int[] temperatures) {
        var res = new int[temperatures.Length];
        // value - index
        var stack = new Stack<(int, int)>(); // Stack is going to always be decreasing order
        
        for(int i = 0; i < temperatures.Length; i++){
            // Only if we have items on stack and the last elem on stack is lower than current temp
            while(stack.Count > 0 && temperatures[i] > stack.Peek().Item1){
                var temp = stack.Pop(); // Remove last element
                res[temp.Item2] = i - temp.Item2; // Assign the days to the lower temp than current
            }
            
            stack.Push((temperatures[i], i)); // Add the current temp to stack
        }
        
        return res;
    }
}