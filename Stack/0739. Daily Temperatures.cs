public class Solution {
    // O(n)
    public int[] DailyTemperatures(int[] temperatures) {
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