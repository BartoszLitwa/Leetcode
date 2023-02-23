public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var map = new Dictionary<int, int>();
        // map each element in nums1 to its index in nums1
        for(int i = 0; i < nums1.Length; i++){
            map.Add(nums1[i], i);
        }
        // initialize the result array with -1
        var res = Enumerable.Repeat(-1, nums1.Length).ToArray();
        var stack = new Stack<int>();
        for(int i = 0; i < nums2.Length; i++){ // keep iterating until i reaches the end
            // remove all the elements that are smaller than the current element
            while(stack.Count > 0 && nums2[i] > stack.Peek()){
                var pop = stack.Pop();
                var index = map[pop]; // get the index of the popped element in nums1
                res[index] = nums2[i]; // update the result array
            }
            // add the current element to the stack if it is in nums1
            if(map.ContainsKey(nums2[i])){
                stack.Push(nums2[i]);
            }
        }

        return res;
    }
}