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
    public string Tree2str(TreeNode root) {
        var sb = new StringBuilder();
        Helper(root);
        sb.Remove(0, 1).Remove(sb.Length - 1, 1); // remove the first and last parenthesis
        return sb.ToString();

        void Helper(TreeNode node){
            if(node is null)
                return;

            sb.Append('('); // add parenthesis
            sb.Append(node.val); // add value
            // if there isnta left child but there is a right child, add empty parenthesis
            if(node.left is null && node.right is not null)
                sb.Append("()");

            Helper(node.left);
            Helper(node.right);

            sb.Append(')'); // close parenthesis
        }
    }
}