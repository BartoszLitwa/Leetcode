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
    // Iterative
    public IList<int> InorderTraversal(TreeNode root) {
        var list = new List<int>();
        var stack = new Stack<TreeNode>();

        var cur = root;
        while(cur != null || stack.Count > 0){
            while(cur != null){ // Traverse max to the left
                stack.Push(cur);
                cur = cur.left;
            }
            cur = stack.Pop(); // Pop the lowest left val
            list.Add(cur.val); // Add to the list
            cur = cur.right; // Shift to the right
        }

        return list;
    }

    // Recursive
    public IList<int> InorderTraversal2(TreeNode root) {
        var res = new List<int>();

        Helper(root);

        return res;

        void Helper(TreeNode root){
            if(root == null)
                return;

            Helper(root.left);
            res.Add(root.val);
            Helper(root.right);
        }
    }
}