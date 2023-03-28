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
    public ListNode DeleteDuplicates(ListNode head) {
        if(head == null) // Empty list
            return head;

        var cur = head; 
        while(cur != null){  // Traverse the list
            while(cur.val == cur.next?.val){ // Duplicate found
                cur.next = cur.next?.next; // Skip it
            }
            cur = cur.next; // Go to next
        }

        return head; // Return the head
    }
}