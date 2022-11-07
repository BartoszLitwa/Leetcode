/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    // Iterative solution
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q){
        // if they are both on the same side - traverse to thise side
        while((double)(root.val - p.val) * (root.val - q.val) > 0){
            root = p.val < root.val ? root.left : root.right;
        }
        
        return root;
    }
    
    // Iterative solution 2
    public TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q){
        while(root != null){
            // both are on the left - traverse left side
            if(p.val < root.val && q.val < root.val)
                root = root.left;
            // both are on the right - traverse right side
            else if(p.val > root.val && q.val > root.val)
                root = root.right;
            // If one is on the left and second one is on the right the root is the ancesotr
            else
                return root;
        }
        
        return root;
    }
    
    // Recursive solution
    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q){
        // both are on the left - traverse left side
        if(p.val < root.val && q.val < root.val){
            return LowestCommonAncestor(root.left, p, q);
        // both are on the right - traverse right side
        } else if(p.val > root.val && q.val > root.val){
            return LowestCommonAncestor(root.right, p, q);
        }
        
        // If one is on the left and second one is on the right the root is the ancesotr
        return root;
    }
}