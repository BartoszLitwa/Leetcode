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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        // WE have to store the first element to access the begining of this LinkedList later
        var result = new ListNode();
        var list = result;
        while(list1 != null && list2 != null){
            if(list1?.val < list2?.val){
                list.next = list1;
                list1 = list1.next;
            } else {
                list.next = list2;
                list2 = list2.next;
            }
            list = list.next;
        }
        // Add the last element that is left
        list.next = list1 != null ? list1 : list2;
        
        // We do not want the first one - 0
        return result.next;
    }
}