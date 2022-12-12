public class Solution {
    public int LastStoneWeight(int[] stones) {
        var sortedList = new SortedList<int, int>(); // Value - count
        int actualSize = 0;
        foreach(var s in stones){
            if(sortedList.ContainsKey(s))
                sortedList[s]++;
            else
                sortedList.Add(s, 1);
            actualSize++;
        }

        while(actualSize > 1){
            var count = sortedList[sortedList.Keys[sortedList.Count - 1]]; // Get the count of the highest value
            var first = sortedList.Keys[sortedList.Count - 1]; // Get the highest value
            // Get the second highest value - if there is only one value with the highest value, get the second highest value
            var second = count > 1 ? sortedList.Keys[sortedList.Count - 1] : sortedList.Keys[sortedList.Count - 2]; 

            if(first == second){ // Destroy both
                sortedList[first] -= 2;
                actualSize -= 2;
                if(sortedList[first] < 1)
                    sortedList.Remove(first);
            } else { // Destroy first and change value of second
                if(sortedList[second] == 1)// Destroy second
                    sortedList.Remove(second);
                else
                    sortedList[second]--;
                actualSize--;

                if(sortedList[first] == 1) // Change value of second
                    sortedList.Remove(first);
                else
                    sortedList[first]--; 

                var value = first - second;
                if(sortedList.ContainsKey(value))
                    sortedList[value]++;
                else
                    sortedList.Add(value, 1);
            }
        }
        
        return sortedList.Count > 0 ? sortedList.Keys[0] : 0;
    }
}