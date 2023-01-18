public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int total = 0;
        int res = 0;
        int gasSum = 0, costSum = 0;
        for(int i = 0; i < gas.Length; i++){
            total += (gas[i] - cost[i]); // add the difference
            gasSum += gas[i];
            costSum += cost[i];

            if(total < 0) { // means we cannot reach the next station
                total = 0;
                res =  i + 1; // set it to next possible
            }
        }
        // We can only travel around only if there is more gas that the cost
        return costSum <= gasSum ? res : -1;
    }
}