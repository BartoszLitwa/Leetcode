public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int max = 0; // Find the max elem
        for(int i = 0; i < piles.Length; i++){
            max = Math.Max(max, piles[i]);
        }
        
        int left = 1, right = max, res = max; // Left and right are not indexes
        while(left <= right){
            int mid = (left + right) / 2;
            //Do a computation
            int time = 0;
            for(int i = 0; i < piles.Length; i++){
                time += (int)Math.Ceiling((double)piles[i] / mid); // Add the needed time to eat from this pile
                if(time > h) // If overall time is greater than h hours
                    break;
            }
            
            if(time > h){ // Takes too much time
                left = mid + 1;
            } else if(time <= h){ // takes less time or just enough
                res = Math.Min(res, mid); // Only when we found time that takes less assign new possible k rate
                right = mid - 1; // Move the pointer to the left
            }
                
        }
        
        return res;
    }
}