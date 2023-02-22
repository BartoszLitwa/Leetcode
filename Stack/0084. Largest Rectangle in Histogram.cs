public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var stack = new Stack<(int Index, int Height)>();
        var res = 0;

        for(int i = 0; i < heights.Length; i++){ // keep iterating until i reaches the end
            var start = i; // the start index of the current rectangle
            // remove all the elements that are larger than the current element
            while(stack.Count > 0 && stack.Peek().Height > heights[i]){
                var pop = stack.Pop(); // pop the top element
                // calculate the area of the rectangle with the popped element as the smallest element
                res = Math.Max(res, pop.Height * (i - pop.Index));
                start = pop.Index; // update the start index
            }
            // add the current element to the stack
            stack.Push((start, heights[i]));
        }

        // calculate the area of the remaining rectangles
        foreach(var s in stack){
            res = Math.Max(res, s.Height * (heights.Length - s.Index));
        }

        return res;
    }
}