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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var list = new List<IList<int>>();
        if(root == null)
            return list;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count > 0){
            // We have to save the size of queue before
            // to prevent it from enqueueing - altering the size
            int size = queue.Count;
            var currList = new List<int>();
            
            // iterate the size of current level
            for(int i = 0; i < size; i++){
                // Dequeue the first element
                var deque = queue.Dequeue();
                // Add its value to the current level
                currList.Add(deque.val);
                
                // Check if we have the left or right node and add it for next level
                if(deque.left != null)
                    queue.Enqueue(deque.left);
                if(deque.right != null)
                    queue.Enqueue(deque.right);
            }
            list.Add(currList);
        }
        
        return list;
    }
    
    public IList<IList<int>> LevelOrder2(TreeNode root) {
        var list = new List<IList<int>>();
        return helper(root, list, 0);
    }
    
    private IList<IList<int>> helper(TreeNode root, IList<IList<int>> list, int level){
        if(root == null)
            return list;
        
        if(list.Count <= level)
            list.Add(new List<int>());
        
        list[level++].Add(root.val);
        
        helper(root.left, list, level);
        helper(root.right, list, level);
        
        return list;
    }
    
    
}