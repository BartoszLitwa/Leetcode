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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p == null && q == null) // Both are the end of the tree
            return true;
        else if(p == null || q == null) // Only one of them is the end of the tree - not the same
            return false;
        else if(p?.val == q?.val) // Both are not null and have the same value
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right); // Check the left and right subtrees
        
        return false;
    }
}