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
    public bool HasPathSum(TreeNode root, int targetSum) {
        return Helper(root, 0);

        bool Helper(TreeNode root, int value){
            if(root == null)
                return false;

            int val = root.val + value;
            if(root.left == null && root.right == null)
                return val == targetSum;

            return Helper(root.left, val) || Helper(root.right, val);
        }
    }
}