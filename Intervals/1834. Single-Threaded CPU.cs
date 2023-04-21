public class Solution {
    public class Item{
        public int enqTime, procTime, index;
    }
    
    public int[] GetOrder(int[][] tasks) {
        var taskList = tasks.Select((x, i) => new Item{enqTime = x[0], procTime = x[1], index = i})
                            .OrderBy(x => x.enqTime)
                            .ToList();

        int index = 0, time = taskList[0].enqTime;
        var res = new int[tasks.Length];
        var minHeap = new List<Item>();

        while(minHeap.Count > 0 || index < taskList.Count){
            while(index < taskList.Count && time >= taskList[index].enqTime){
                minHeap.Add(taskList[index++]);
            }

            if(minHeap.Count <= 0){
                time = taskList[index].enqTime;
            } else {
                var pop = minHeap[0];
                minHeap.RemoveAt(0);
                time += pop.procTime;
                res[index++] = pop.index;
            }
        }

        return res;
    }
}