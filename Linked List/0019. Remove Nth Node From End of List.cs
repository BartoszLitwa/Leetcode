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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(-1, head); // Create the first node that sits before
        ListNode left = dummy, right = head; // Set left at our -1th node to keep it beofre node that we want to delete
        while(n > 0 && right != null){ // Move right n times
            right = right.next;
            n -=1;
        }
        
        while(right != null){ // Loop until right pointer reaches the end
            left = left.next;
            right = right.next;
        }
        
        left.next = left.next.next; // Relink the list wihout our deleted node
        return dummy.next; // We dont want to return Linked list with our dommy node
    }
}