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
    // DFS solution
    public TreeNode InvertTree(TreeNode root) {
        if(root == null)
            return null;
        
        // Swap children
        var left = root.left;
        root.left = root.right;
        root.right = left;
        
        InvertTree(root.left);
        InvertTree(root.right);
        
        return root;
    }

    // BFS solution
    public TreeNode InvertTree(TreeNode root) {
        if(root == null)
            return null;
        
        var que = new Queue<TreeNode>();
        que.Enqueue(root);
        
        while(que.Count > 0){
            // Swap children
            var deq = que.Dequeue();
            var left = deq.left;
            deq.left = deq.right;
            deq.right = left;
            
            if(deq.left != null){
                que.Enqueue(deq.left);
            }
            if(deq.right != null){
                que.Enqueue(deq.right);
            }
        }
        
        return root;
    }
}