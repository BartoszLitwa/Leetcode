public class KthLargest {
    private readonly int k;
    private readonly SortedList<int, int> elements; // Value, count
    private int acutalSize;

    public KthLargest(int k, int[] nums){
        this.k = k;
        this.elements = new SortedList<int, int>();
        this.acutalSize = 0;
        foreach (int num in nums){
            Add(num);
        }
    }

    public int Add(int val){
        if(elements.ContainsKey(val)) // If it is a duplicate
            elements[val]++;
        else
            elements.Add(val, 1); // Add the value with count 1
        acutalSize++; // Increase real size

        if(acutalSize > k){
            var count = elements.Values[0]; // Get the count of the lowest value
            if(count > 1) // Duplicate
                elements[elements.Keys[0]]--;
            else
                elements.RemoveAt(0);

            acutalSize--;
        }

        return elements.Keys[0]; // Return the min value
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */