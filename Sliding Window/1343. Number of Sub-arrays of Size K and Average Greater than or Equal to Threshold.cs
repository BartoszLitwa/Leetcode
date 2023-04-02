public class Solution {
    public int NumOfSubarrays(int[] arr, int k, int threshold) {
        int left = 0, right = 0;
        int result = 0;
        int sum = 0;

        for(int i = 0; i < k; i++){ // First window
            sum += arr[right++];
        }

        while (right < arr.Length) { // Sliding window
            if(sum >= threshold * k){
                result++;
            }
            // Add the right element and remove the left element
            sum += -arr[left++] + arr[right++];
        }

        if(sum >= threshold * k){ // Check the last window
            result++;
        }

        return result;
    }
}