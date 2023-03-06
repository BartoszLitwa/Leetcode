public class Solution {
    // Easier solution would be a bucket sort - counting occurrences of each number
    // Merge sort with partitioning
    public void SortColors(int[] nums) {
        int left = 0, right = nums.Length - 1;
        int i = 0;

        while(i <= right){ // Until the right pointer is reached
            if(nums[i] == 0){ // If the current number is 0, swap it with the number at the left pointer and increment both pointers
                Swap(i, left++);
            } else if(nums[i] == 2){ // If the current number is 2, swap it with the number at the right pointer and decrement the right pointer
                Swap(i, right--);
                i--; // Decrement the current pointer to check the new number at the current position
            }
            // Numer 1 will stay in place - middle between left and right
            i++;
        }

        void Swap(int a, int b){
            int temp = nums[b];
            nums[b] = nums[a];
            nums[a] = temp;
        }
    }
}