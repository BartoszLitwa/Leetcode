//Linked list
public class MinStack {
    Node head;
    
    public MinStack() {
    }
    
    public void Push(int val) {
       if(head == null){
           head = new Node(val, val, null);
       } else {
           head = new Node(val, Math.Min(head.min, val), head);
       }
    }
    
    public void Pop() {
        head = head.prev;
    }
    
    public int Top() {
        return head.val;
    }
    
    public int GetMin() {
        return head.min;
    }
}

public class Node{
    public int val;
    public int min;
    public Node prev;
    
    public Node(int _val, int _min, Node _prev){
        val = _val;
        min = _min;
        prev = _prev;
    }
}

// Using 1 stack
public class MinStack {
    Stack<int> _stack;
    int _min = Int32.MaxValue;
    
    public MinStack() {
        _stack = new Stack<int>();
    }
    
    public void Push(int val) {
        // <= is important in this case. Since when we push new "min" val the same as we used to have previously
        // we still want to push it on stack as our previous min
        if(val <= _min){ // If we found new min push old min to the stack
            _stack.Push(_min); // Push old min
            _min = val; // replace it with new min value
        }
        
        _stack.Push(val); // Push our newest value
    }
    
    public void Pop() {
        if(_stack.Pop() == _min) // If we pop the current min value 
            _min = _stack.Pop(); // the previous value on stack is our previous min
    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return _min;
    }
}

// Using 2 stack
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