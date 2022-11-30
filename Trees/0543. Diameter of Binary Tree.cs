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
    // For every node, length of longest path which pass it = MaxDepth of its left subtree +        MaxDepth of its right subtree.
    int max = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        MaxDepth(root, 0);
        return max;
    }
    
    private int MaxDepth(TreeNode node, int depth){
        if(node == null)
            return 0;
        
        int left = MaxDepth(node.left, depth + 1); // MaxDepth of left subtree
        int right = MaxDepth(node.right, depth + 1); // MaxDepth of right subtree
        max = Math.Max(max, left + right); // Set the max value
        return Math.Max(left, right) + 1; // Return whichever is greater
    }
}