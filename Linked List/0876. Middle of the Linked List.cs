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
    public ListNode MiddleNode(ListNode head) {
        // Slow will be moving 1 node forward, when the fast will be 2 forward
        ListNode slow = head, fast = head;
        while(fast != null && fast.next != null){
            fast = fast.next.next;
            slow = slow.next;
        }
        
        return slow;
    }

    public ListNode MiddleNode2(ListNode head) {
        int index = 0;
        
        var temp = head;
        // Find how many elements there are
        while(temp != null){
            temp = temp.next;
            index++;
        }
        
        // Loop it until we reach the middle
        for(int i = 0; i < index / 2; i++){
            head = head.next;
        }
        
        // Return the middle node
        return head;
    }
}