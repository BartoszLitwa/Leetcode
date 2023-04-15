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
    public int PairSum(ListNode head) {
        ListNode slow = head, fast = head;
        ListNode prev = null;
        while(fast is not null && fast.next is not null){
            fast = fast.next.next; // fast move 2 steps

            var tmp = slow.next; // reverse the first half
            slow.next = prev; // Set to the previous
            prev = slow; // Set previous to current
            slow = tmp; // move to next - original next
        }

        int res = 0;
        while(slow is not null){ // Prev is left half, slow is right half
            res = Math.Max(res, prev.val + slow.val);
            prev = prev.next;
            slow = slow.next;
        }

        return res;
    }
}