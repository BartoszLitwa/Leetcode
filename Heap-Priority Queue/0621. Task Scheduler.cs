public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var map = new int[26];
        var list = new SortedList<int, int>(); // Count - how many duplicates

        for(int i = 0; i < tasks.Length; i++){ // Count the occurances
            map[tasks[i] - 'A']++;
        }

        for(int i = 0; i < map.Length; i++){ // Add every letter that count is greater than 0
            if(map[i] == 0)
                continue;
            
            if(list.ContainsKey(map[i])){
                list[map[i]]++;
            } else {
                list.Add(map[i], 1);
            }
        }

        var que = new Queue<(int Count, int IdleTime)>();

        int time = 0;
        while(list.Count > 0 || que.Count > 0){ // Loop through each elem that is still in queue and our maxHeap
            time++;
            if(list.Count > 0){
                int count = list.Keys[list.Count - 1] - 1; // Decrement the count since we are using it now
                if(list[list.Keys[list.Count - 1]] > 1){ // If the last elem has duplicates
                    list[list.Keys[list.Count - 1]]--; // Remove the duplicate
                } else {
                    list.RemoveAt(list.Count - 1); // Remove it from the maxHeap
                }
                if(count != 0)
                    que.Enqueue((count, time + n)); // Append the count and time when its going to be available again
            }

            if(que.Count > 0 && que.Peek().IdleTime <= time){ // If we have anything in queue that is available
                var tuple = que.Dequeue();
                if(list.ContainsKey(tuple.Count)){
                    list[tuple.Count]++; // Increase the number of duplicates
                } else {
                    list.Add(tuple.Count, 1); // Add it again to the maxHeap
                }
            }
        }

        return time;
    }
}