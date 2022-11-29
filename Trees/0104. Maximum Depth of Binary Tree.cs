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
    // Iterative DFS solution
    public int MaxDepth(TreeNode root){
        if(root == null)
            return 0;
        
        int level = 0;
        var stack = new Stack<(TreeNode, int)>();
        stack.Push((root, 1));
        
        while(stack.Count > 0){
            var pop = stack.Pop();
            level = Math.Max(level, pop.Item2);
            if(pop.Item1.left != null)
                stack.Push((pop.Item1.left, pop.Item2 + 1));
            if(pop.Item1.right != null)
                stack.Push((pop.Item1.right, pop.Item2 + 1));
        }
        
        return level;
    }

    // BFS Solution
    public int MaxDepth3(TreeNode root){
        if(root == null)
            return 0;
        
        int level = 0;
        var que = new Queue<TreeNode>();
        que.Enqueue(root);
        
        while(que.Count > 0){ // Until we looked at each node
            var len = que.Count; // Store the number of nodes in queue
            for(int i = 0; i < len; i++){
                var deq = que.Dequeue(); // Pop from the que and its children
                if(deq.left != null)
                    que.Enqueue(deq.left);
                if(deq.right != null)
                    que.Enqueue(deq.right);
            }
            level++; // Increase the level
        }
        
        return level;
    }

    // Recursive DFS solution
    public int MaxDepth(TreeNode root){
        if(root == null)
            return 0;
        
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
    
    private int res = 1;
    public int MaxDepth2(TreeNode root) {
        if(root == null)
            return 0;
        
        Depth(root, res);
        return res;
    }
    
    private void Depth(TreeNode node, int depth){
        if(node == null)
            return;
        
        res = Math.Max(res, depth);
        
        Depth(node.left, depth + 1);
        Depth(node.right, depth + 1);
    }
}