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
    public ListNode MergeKLists(ListNode[] lists) {
        // If there is no list, return null
        if(lists == null || lists.Length == 0)
            return null;

        while(lists.Length > 1){ // If there is only one list, return it
            var mergedLists = new List<ListNode>(); // Store the merged lists
            for(int i = 0; i < lists.Length; i += 2){ // Merge 2 lists at a time
                var list1 = lists[i]; // Get the first list
                // There could be an odd number of lists, so we need to check if the next list exists
                var list2 = i + 1 < lists.Length ? lists[i + 1] : null;
                // Merge the 2 lists and add it to the mergedLists
                mergedLists.Add(Merge2Lists(list1, list2));
            } // After this loop, we have merged all the lists
            lists = mergedLists.ToArray();
        }
        // Return the last ListNode
        return lists[0];
    }

    private ListNode Merge2Lists(ListNode l1, ListNode l2){
        var result = new ListNode(); // Store the first element
        var list = result;
        while(l1 != null && l2 != null){ // While there are elements in both lists
            if(l1.val < l2.val){ // l1.val < l2.val
                list.next = l1; // Add the smaller element to the list
                l1 = l1.next; // Move to the next element
            } else { // l1.val >= l2.val
                list.next = l2; // Add the smaller element to the list
                l2 = l2.next; // Move to the next element
            }
            list = list.next; // Move to the next element
        }
        // Add the last element that is left
        list.next = l1 != null ? l1 : l2;
        // We do not want the first one, since it always null
        return result.next;
    }
}