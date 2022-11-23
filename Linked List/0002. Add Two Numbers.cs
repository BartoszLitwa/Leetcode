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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode res = new ListNode(-1, null);
        ListNode first = res; // Save the first node to return it
        int helper = 0;
        while(l1 != null || l2 != null){
            int currVal = ((l1?.val ?? 0) + (l2?.val ?? 0) + helper); //Add all the current val of nodes and the carry number
            res.val = currVal % 10; // Nodes value is current value modulo 10
                
            helper = currVal / 10; // Store the carry number for next loop
            // Add the new node only if we have nodes to loop or we have carry number
            if(l1?.next != null || l2?.next != null || helper > 0){ 
                res.next = new ListNode(helper, null); // Initialize the node value with carry number
                res = res.next; // Go to next node
            }
            
            // Go to next node
            l1 = l1?.next;
            l2 = l2?.next;
        }
        
        return first;
    }
}