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
    public bool IsPalindrome(ListNode head) {
        ListNode slow = head, fast = head;
        // Find middle - slow
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode prev = null;
        while(slow != null){ // Reverse 2nd half
            var tmp = slow.next; //Save 
            slow.next = prev; // Reverse 
            prev = slow; // Set prev as the current
            slow = tmp; // Go to the next
        }

        //Check palindrome - prev is going to be last
        ListNode left = head, right = prev;
        while(right != null){ // right was reversed so it will reach null first
            if(left.val != right.val)
                return false;

            left = left.next;
            right = right.next;
        }

        return true;
    }
}