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
    public ListNode ReverseKGroup(ListNode head, int k) {
        var dummy = new ListNode(0, head);
        var groupPrev = dummy;
        var groupNext = dummy;

        while(true){ // Loop through all the groups
            var kth = GetKthNode(groupPrev, k); // Get the kth node in the group
            if(kth == null)
                break;

            // Get the node that is after this sublist
            groupNext = kth.next;

            // prev is the first node in the next group
            // curr is the first node in the current group
            ListNode prev = kth.next, curr = groupPrev.next;
            while(curr != groupNext){ // Reverse the group
                var tmp = curr.next; // Store the next node
                curr.next = prev; // Reverse the link
                prev = curr; // Move prev to curr
                curr = tmp; // Move curr to the next node
            }

            var temp = groupPrev.next; // First node in the group
            groupPrev.next = kth; // Link the previous group to the current group
            groupPrev = temp; // Move the groupPrev to the first node in the next group
        }
        // Return the head of the reversed list
        return dummy.next;
    }

    private ListNode GetKthNode(ListNode node, int k){
        while(node != null && k > 0){
            node = node.next;
            k--;
        }
        return node;
    }
}