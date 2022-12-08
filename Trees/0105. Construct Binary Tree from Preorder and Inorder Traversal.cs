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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(preorder.Length < 1 || inorder.Length < 1)
            return null;

        var root = new TreeNode(preorder[0]);
        var mid = Array.IndexOf(inorder, preorder[0]); // Find the root value

        root.left = BuildTree(preorder.Skip(1).Take(mid + 1).ToArray(), // Take the array after first item up to mid + 1
                                 inorder.Take(mid).ToArray()); // Take array to the left of the mid

        root.right = BuildTree(preorder.Skip(mid + 1).ToArray(), // Take array to the right of mid
                                 inorder.Skip(mid + 1).ToArray()); // Take array to the right of mid

        return root;
    }
}