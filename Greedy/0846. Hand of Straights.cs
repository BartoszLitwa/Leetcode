public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0) // When it is not dividable by k
            return false; // we cannot create k sets

        var dict = new Dictionary<int, int>();
        var sorted = new List<int>();
        for(int i = 0; i < hand.Length; i++){ // Count the occurances
            if(dict.ContainsKey(hand[i])){
                dict[hand[i]]++;
            } else {
                dict.Add(hand[i], 1);
                if(!sorted.Contains(hand[i])) // Add only 1 copy
                    // since we will be removing it only after there are no copies left
                    sorted.Add(hand[i]);
            }
        }
        sorted.Sort();

        while(sorted.Count > 0){
            var first = sorted[0];
            for(int i = first; i < first + groupSize; i++){
                if(!dict.ContainsKey(i)) // We cannot create consecutive group
                    return false;

                if(--dict[i] == 0){ // Check if it was the last one
                    if(i != sorted[0]) // its not the smallest available
                        return false;

                    sorted.RemoveAt(0); // Remove it from the beginning
                }
            }
        }

        return true;
    }
}