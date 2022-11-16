/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null)
            return false;
        
        // slow and fast pointers
        ListNode left = head, right = head.next;
        
        while(left != right){
            if(right == null || right.next == null) // There is no cycle
                return false;
            
            left = left.next; // Move 1 forward
            right = right.next.next; // Move 2 forward
        }
        
        return true;
    }
}