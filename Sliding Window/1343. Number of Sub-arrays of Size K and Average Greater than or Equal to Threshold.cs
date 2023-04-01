public class Solution {
    public int NumOfSubarrays(int[] arr, int k, int threshold) {
        int left = 0, right = 0;
        int result = 0;
        int sum = 0;

        for(int i = 0; i < k; i++){
            sum += arr[right++];
        }

        while (right < arr.Length) {
            if(sum >= threshold * k){
                result++;
            }

            sum += -arr[left++] + arr[right++];
        }

        if(sum >= threshold * k){
            result++;
        }

        return result;
    }
}