public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        m--; // make m and n point to the last element
        n--;
        while(m >= 0 && n >= 0){ // merge from the end
            if(nums1[m] > nums2[n]) // put the larger one to the end
                nums1[m + n + 1] = nums1[m--];
            else
                nums1[m + n + 1] = nums2[n--];
        }

        while(n >= 0){ // if nums2 is not empty, put the rest to nums1
            nums1[m + n + 1] = nums2[n--];
        }
    }
}