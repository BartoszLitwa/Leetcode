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
    public bool IsValidBST(TreeNode root) {
        var list = new List<int>();
        if(root == null)
            return true;
        
        var stack = new Stack<TreeNode>();
        double prevLeftVal = Double.MinValue;
        while(root != null || stack.Count > 0){
            while(root != null){ // Iterate the left side of tree and push it to stack
                stack.Push(root);
                root = root.left;
            }
            
            // Get the most bottom left node 
            root = stack.Pop();
            // Make sure parent val is NOT less or equal to left child value
            if(root.val <= prevLeftVal)
                return false;
            
            // Assign current value as previous left value
            prevLeftVal = root.val;
            // Add right node to the stack
            root = root.right;
        }
            
        return true;
    }
    
    // Recursive
    public bool IsValidBST2(TreeNode root) {
        return helper(root, Double.MinValue, Double.MaxValue);
    }
    
    private bool helper(TreeNode node, double min, double max){
        if(node == null)
            return true;
        
        if(node.val <= min || node.val >= max)
            return false;
        else
            return helper(node.left, min, node.val) && helper(node.right, node.val, max);
    }
}