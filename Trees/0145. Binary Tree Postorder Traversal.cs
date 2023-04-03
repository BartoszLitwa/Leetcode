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
    public IList<int> PostorderTraversal(TreeNode root) {
        var list = new List<int>();
        if(root == null) // If root is null, return empty list
            return list;

        var stack = new Stack<TreeNode>();
        stack.Push(root); // Add root to stack
        while(stack.Count > 0){
            var pop = stack.Pop(); // Pop node
            list.Insert(0, pop.val); // Add node to the begining of the list
            if(pop.left != null) // Add left side children to stack
                stack.Push(pop.left);
            if(pop.right != null) // Add right side children to stack
                stack.Push(pop.right);
        }

        return list;
    }
}