public class MyStack {
    private Queue<int> queue;

    public MyStack() {
        queue = new Queue<int>();
    }
    
    public void Push(int x) {
        queue.Enqueue(x);
    }
    
    public int Pop() {
        var len = queue.Count - 1; // -1 because we dont want to pop the last element
        while(len-- > 0){
            var pop = queue.Dequeue(); // Pop the first element
            queue.Enqueue(pop); // Add it to the end of the queue
        }
        return queue.Dequeue(); // Pop the last element
    }
    
    public int Top() {
        return queue.Last(); // Get the last element
    }
    
    public bool Empty() {
        return queue.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */