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
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        return Helper(root1, root2);
        
        TreeNode Helper(TreeNode r1, TreeNode r2){
            if(r1 == null && r2 == null) // Base case
                return null;
            if(r1 == null) // If r1 is null, return r2
                return r2;
            if(r2 == null) // If r2 is null, return r1
                return r1;

            var node = new TreeNode(r1.val + r2.val); // Sum the values
            node.left = Helper(r1.left, r2.left); // Traverse left
            node.right = Helper(r1.right, r2.right); // Traverse right

            return node;
        }
    }
}