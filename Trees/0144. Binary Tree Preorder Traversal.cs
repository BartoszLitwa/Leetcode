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
    public IList<int> PreorderTraversal(TreeNode root) {
        var res = new List<int>();
        var stack = new Stack<TreeNode>(); // Right side children
        while(root != null){
            res.Add(root.val); // Add node
            if(root.right != null) // Add right side children to stack
                stack.Push(root.right);
            root = root.left; // Traverse left
            if(root == null && stack.Count > 0) // If left is null, pop right
                root = stack.Pop();
        }
        return res;
    }
}