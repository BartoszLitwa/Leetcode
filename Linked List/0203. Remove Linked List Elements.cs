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
    public ListNode RemoveElements(ListNode head, int val) {
        if(head == null) // Empty list
            return head;
        
        var dummy = new ListNode() { next = head }; // Dummy node
        var cur = dummy; // Save the head
        
        while (cur != null) { // Traverse the list
            if (cur?.next?.val == val) // Value found
                cur.next = cur.next.next; // Skip it
            else
                cur = cur.next; // Go to next
        }
        
        return dummy.next;
    }
}