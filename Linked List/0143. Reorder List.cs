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
    public void ReorderList(ListNode head){
        // Find the middle
        ListNode slow = head, fast = head.next;
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // Beginning of the second list
        var second = slow.next;
        slow.next = null; // break the link between 2 halfs
        
        // Reverse the second half
        ListNode prev = null;
        while(second != null){
            var temp = second.next; //store the current next node;
            second.next = prev; //set the current's next node as previous
            prev = second; // set the previous node as modfied current with next as prev
            second = temp; // revert second to the original state to iterate to the end
        }
        
        // Merge
        ListNode first = head, reversed = prev; // Prev has the last reversed node
        while(reversed != null){ // loop until the last elem of reversed list
            ListNode temp1 = first.next, temp2 = reversed.next; // store next's elem of both
            first.next = reversed; // set as second elem the current of reversed
            reversed.next = temp1; // 
            first = temp1; // move the pointer to the next elem
            reversed = temp2;
        }
    }
    
    public void ReorderList2(ListNode head) {
        var list = new List<ListNode>();
        var node = head;
        while(node != null){
            list.Add(node);
            node = node.next;
        }

        for(int i = 0; i < list.Count - 1; i++){
            if(i % 2 != 0){ // odd
                head.next = list[1 + (i / 2)];
            } else {
                head.next = list[list.Count - 1 - (i / 2)];
            }
            head = head.next;
        }
        head.next = null;
    }
}