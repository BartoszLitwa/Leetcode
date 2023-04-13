/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if(headA is null || headB is null) // Base case
            return null;

        ListNode a = headA, b = headB;

        while(a != b){ // Until a and b are the same
            // If we reach the end of a list, then we start at the beginning of the list
            a = a is null ? headB : a.next; // Otherwise we move to the next node
            b = b is null ? headA : b.next;
        }

        return a; // Return the intersection node
    }
}