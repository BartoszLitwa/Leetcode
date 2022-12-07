/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        int n = 0;
        var stack = new Stack<TreeNode>();
        var cur = root;

        // Until we did not traverse whole tree
        while(cur != null || stack.Count > 0){
            while(cur != null){ // traverse to the left
                stack.Push(cur); // add the value to the stack
                cur = cur.left;
            }
            cur = stack.Pop(); // pop the value
            
            if(++n == k){ // Add + 1 to n since the most left node should be the lowest one
                return cur.val;
            }

            cur = cur.right; // traverse to the right
        }

        return 0;
    }
}