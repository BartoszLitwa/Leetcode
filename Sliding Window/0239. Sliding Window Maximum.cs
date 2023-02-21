public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var list = new List<int>();
        int left = 0, right = 0;
        var que = new LinkedList<int>();

        while(right < nums.Length){ // keep iterating until right reaches the end
            // remove all the elements that are smaller than the current element
            while(que.Count > 0 && nums[que.Last.Value] < nums[right])
                que.RemoveLast();
            // add the current element to the end of the queue
            que.AddLast(right);
            // remove the first element if it is out of the window
            if(left > que.First.Value)
                que.RemoveFirst();
            // add the first element to the result list if we reached the window size
            if(++right >= k) {
                list.Add(nums[que.First.Value]);
                left++; // move the window
            }
            
        }

        return list.ToArray();
    }
}