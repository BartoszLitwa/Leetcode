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
    public bool IsSymmetric(TreeNode root) {
        if(root == null) // Empty tree is symmetric
            return true;

        return Helper(root.left, root.right);

        bool Helper(TreeNode left, TreeNode right){
            if(left == null && right == null) // Both are null
                return true;
            if(left == null || right == null) // One is null
                return false;
            if(left.val != right.val) // Values are different
                return false;
            // Check if values are mirrored
            return Helper(left.left, right.right) && Helper(left.right, right.left);
        }
    }
}