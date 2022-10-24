/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        // Set it to nothing to - last node points to nothing
        return reverse(head, null);
    }
    
    private ListNode reverse(ListNode head, ListNode prev){
        if(head == null)
            return prev;
        
        // Store next Node
        var next = head.next;
        // Next node should point to previous
        head.next = prev;
        
        // Set previous node to current one
        return reverse(next, head);
    }
    
    public ListNode ReverseList2(ListNode head) {
        // Set it to nothing to - last node points to nothing
        ListNode prevHead = null;
        
        while(head != null){
            // Store next Node
            var nextHead = head.next;
            
            // Next node should point to previous
            head.next = prevHead;
            // Set previous node to current one
            prevHead = head;
            
            // Restore Original next Item
            head = nextHead;
        }
        
        return prevHead;
    }
}