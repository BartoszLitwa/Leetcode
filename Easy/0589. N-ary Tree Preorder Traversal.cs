/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    // Iterative
    public IList<int> Preorder(Node root) {
        var list = new List<int>();
        var stack = new Stack<Node>();
        
        if(root == null)
            return list;
        
        // Add the head node
        stack.Push(root);
        
        while(stack.Count > 0){
            // Remove node from top of the stack
            var node = stack.Pop();
            // Add its value
            list.Add(node.val);
            
            for(int i = node.children.Count - 1; i >= 0; i--){
                // Add node's children in reverse order
                // so we can pop each one
                stack.Push(node.children[i]);
            }
        }
        
        return list;
    }
    
    // Recursive
    public IList<int> Preorder2(Node root) {
        var list = new List<int>();
        return helper(root, list);
    }
    
    private IList<int> helper(Node root, IList<int> list){
        if(root == null) 
            return list;
        
        list.Add(root.val);
        
        foreach(var node in root.children){
            helper(node, list);
        }
        
        return list;
    }
}