public class MinStack {
    Stack<int> _stack; // Store the values
    Stack<int> _min; // store the last min values

    public MinStack() {
        _stack = new Stack<int>();
        _min = new Stack<int>();
    }
    
    public void Push(int val) {
        _stack.Push(val);
        _min.Push(Math.Min(_min.Count == 0 ? val : _min.Peek(), val));
    }
    
    public void Pop() {
        _stack.Pop();
        _min.Pop();
    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return _min.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */