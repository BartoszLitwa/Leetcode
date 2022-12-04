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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(subRoot == null) // It always will be true
            return true;
        if(root == null) // SubTree is not empty
            return false;
        
        if(SameTree(root, subRoot)) // Check if subRoot is the subtree of the current root
            return true;
        
        // If not check for left and right node of the current node
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }
    
    private bool SameTree(TreeNode root, TreeNode sub) {
        if(root == null && sub == null)
            return true;
        else if(root != null && sub != null && root?.val == sub?.val)
            return SameTree(root.left, sub.left) && SameTree(root.right, sub.right);
        
        return false;
    }
}