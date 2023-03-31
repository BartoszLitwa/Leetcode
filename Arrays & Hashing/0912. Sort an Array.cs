public class Solution {
    public int[] SortArray(int[] nums) {
        return MergeSort(nums, 0, nums.Length - 1);

        int[] MergeSort(int[] arr, int left, int right){
            if(left == right) // Base case
                return arr;
            
            int mid = (left + right) >> 1; // (left + right) / 2
            MergeSort(arr, left, mid); // Sort left half
            MergeSort(arr, mid + 1, right); // Sort right half
            Merge(arr, left, right, mid); // Merge two halves

            return arr;
        }

        void Merge(int[] arr, int left, int right, int mid){
            int[] leftArr = arr[left..(mid + 1)], // [left, mid]
                  rightArr = arr[(mid + 1)..(right + 1)]; // [mid + 1, right]

            // Pointers
            int p = left, l = 0, r = 0;
            while(l < leftArr.Length && r < rightArr.Length){ // Merge while both arrays have elements
                arr[p++] = leftArr[l] <= rightArr[r] 
                    ? leftArr[l++] : rightArr[r++];
            }

            while(l < leftArr.Length){ // Merge the remaining elements
                arr[p++] = leftArr[l++];
            }

            while(r < rightArr.Length){ // Merge the remaining elements
                arr[p++] = rightArr[r++];
            }
        }
    }
}