public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        // Store each found matching index of i-th number of a triplet
        var hashSet = new HashSet<int>();
        for(int i = 0; i < triplets.Length; i++){
            if(triplets[i][0] > target[0] || triplets[i][1] > target[1] ||
               triplets[i][2] > target[2]) // Check if this triplet each int is in "bounds" 
               continue;

            for(int j = 0; j < triplets[i].Length; j++){
                if(triplets[i][j] == target[j]){ // Find the exact int that matches target
                    hashSet.Add(j); // Add the triplets i-th int index
                }
            }
        }
        // We check if we found exact number for each int of the triplet
        return hashSet.Count == 3;
    }
}