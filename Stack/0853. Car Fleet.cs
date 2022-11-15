public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var arr = new (int, int)[position.Length];
        // Make a tuple array - C# doesnt allow dictionary with dupliates
        for(int i = 0; i < position.Length; i++){
            arr[i] = (position[i], speed[i]);
        }
        Array.Sort(arr); // Sort the array
        
        double currentBlocking = 0;
        int count = 0;
        for(int i = arr.Length - 1; i >= 0; i--){
            // We want to keep decimal point - time needed to get to the target
            var current = (double)(target - arr[i].Item1) / (double)arr[i].Item2;
            // If current car has longer time needed than previous
            if(current > currentBlocking){ 
                count++;
                currentBlocking = current; // Remove last car - it is a car fleet
            }
        }
        
        return count;
    }
}