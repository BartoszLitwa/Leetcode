public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.Length <= 0 && nums2.Length == 1)
            return nums2[0]; // Edge case
        if (nums2.Length <= 0 && nums1.Length == 1)
            return nums1[0]; // Edge case
        // We want to run BS on the smaller array
        if(nums1.Length > nums2.Length){ // Swap places
            return FindMedianSortedArrays(nums2, nums1);
        }

        int total = nums1.Length + nums2.Length;
        int half = (total) / 2;
        // Set the pointers
        int left = 0, right = nums1.Length;
        while(left <= right){ // We are running BS on smaller array
            var midSmaller = left + (right - left) / 2; // Mid of smaller array
            var midLarger = half - midSmaller; // Mid of larger array
            // left is mid - 1, right is mid
            var smallerLeft = (midSmaller > 0) ? nums1[midSmaller - 1] : int.MinValue;
            var smallerRight = (midSmaller < nums1.Length) ? nums1[midSmaller] : int.MaxValue;
            var largerLeft = (midLarger > 0) ? nums2[midLarger - 1] : int.MinValue;
            var largerRight = (midLarger < nums2.Length) ? nums2[midLarger] : int.MaxValue;
            // If both parts are correct, return the median
            if(smallerLeft <= largerRight && largerLeft <= smallerRight){
                if(total % 2 != 0) // Odd
                    return Math.Min(smallerRight, largerRight);
                // Even
                return (Math.Max(smallerLeft, largerLeft) + Math.Min(smallerRight, largerRight)) / 2d;
            } else if(smallerLeft > largerRight){ // smaller's last item is bigger then larger's first item
                right = midSmaller - 1;
            } else { // larger's last item is bigger then smaller's first item
                left = midSmaller + 1;
            }
        }
        // Should never reach here
        return 0;
    }
}