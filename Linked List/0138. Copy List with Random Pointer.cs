/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if(head == null)
            return null;

        var dict = new Dictionary<Node, Node>();
        
        var temp = head; // Create the hash map with mapping of old node to new node
        while(temp != null){
            var copy = new Node(temp.val);
            dict.Add(temp, copy); // Map new/copied node to the old one
            temp = temp.next;
        }
        
        temp = head;
        while(temp != null){ // Modify the next and random pointers of the new nodes
            var copy = dict[temp]; // Get the copy of the current node
            copy.next = temp.next == null ? null : dict[temp.next];
            copy.random = temp.random == null ? null : dict[temp.random]; // Map the copied random node
            
            temp = temp.next;
        }
        
        return dict[head]; // Get the first element of the copied linked list
    }
}