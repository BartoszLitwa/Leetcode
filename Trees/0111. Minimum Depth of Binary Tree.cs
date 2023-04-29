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
    public int MinDepth(TreeNode root) { // BFS
        if(root is null)
            return 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root); // add root to queue
        int level = 1;
        while(queue.Count > 0){
            var size = queue.Count(); // get size of current level
            for(int i = 0; i < size; i++){ // iterate through current level
                var node = queue.Dequeue();
                if(node.left is null && node.right is null)
                    return level; // return level if node is leaf
                if(node.left is not null) // add children to queue
                    queue.Enqueue(node.left);
                if(node.right is not null)
                    queue.Enqueue(node.right);
            }
            level++; // increment level if not found leaf
        }

        return level;
    }
}