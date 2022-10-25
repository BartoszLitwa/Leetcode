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
    // Floyd's cycle detecting Algorithm
    // Distance traveled by slow when they meet: L1+L2
    // Distance traveled by fast when they meet: L1+2L2+x, where x is the remaining length of the cycle (meeting point to start of the cycle).
    // 2(L1+L2) = L1+2L2+x
    // 2L1 + 2L2 = L1+2L2+x
    // => x = L1
    public ListNode DetectCycle(ListNode head) {
        // p - will move 1 forward and q 2 forward
        ListNode p = head, q = head;
        
        while(p != null && q != null && q.next != null){
            p = p.next;
            q = q.next.next;
            
            // Detect if there is a loop
            if(p == q)
                return startLoop(p, head);
        }
        
        return null;
    }
    
    private ListNode startLoop(ListNode p, ListNode head){
        var q = head;
        while(p != q){
            p = p.next;
            q = q.next;
        }
        return p;
    }
    
    public ListNode DetectCycle2(ListNode head) {
        var list = new List<ListNode>();
        
        while(head != null){
            if(!list.Contains(head)){
                list.Add(head);
            } else {
                return head;
            }
            
            head = head.next;
        }
        
        return null;
    }
}