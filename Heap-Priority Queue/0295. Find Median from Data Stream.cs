public class MedianFinder {
    private PriorityQueue<int, int> minHeap;
    private PriorityQueue<int, int> maxHeap;

    public MedianFinder() {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        maxHeap.Enqueue(num, num); // Add to the max heap
        // We do not have minHeap so we have to artificially reverse the order by multiplying by -1
        minHeap.Enqueue(maxHeap.Peek(), -1 * maxHeap.Dequeue()); // Move the max to the min
        if(minHeap.Count > maxHeap.Count) // If the min is bigger
            maxHeap.Enqueue(minHeap.Peek(), minHeap.Dequeue()); // Move the min to the max
    }
    
    public double FindMedian() {
        return minHeap.Count == maxHeap.Count ?
            (minHeap.Peek() + maxHeap.Peek()) / 2.0 // Count is even so we return the average
            : maxHeap.Peek(); // Count is odd so we return the max
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */