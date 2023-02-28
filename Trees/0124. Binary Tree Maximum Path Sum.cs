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
    public int MaxPathSum(TreeNode root) {
        var res = root.val; // Max value
        // Return the max value of the tree
        return Math.Max(Dfs(root), res);

        int Dfs(TreeNode root){
            if(root == null) // Base case
                return 0; // Return 0 if the node is null
            // Since we want max value we don't want to add negative values
            var left = Math.Max(Dfs(root.left), 0);
            var right = Math.Max(Dfs(root.right), 0);
            // Value when we split to left and right not going up the tree
            res = Math.Max(res, root.val + left + right); // Update the max value
            return Math.Max(left, right) + root.val; // Return the max value of the subtree
        }
    }
}