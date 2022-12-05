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
    public IList<int> RightSideView(TreeNode root) {
        var res = new List<int>();
        if(root == null)
            return res;
        
        var que = new Queue<TreeNode>();
        que.Enqueue(root);
        
        while(que.Count > 0){
            var len = que.Count;
            int? lastToAdd = null;
            
            while(len-- > 0){
                var deq = que.Dequeue();
                lastToAdd = deq.val;
                
                if(deq.left != null){
                    que.Enqueue(deq.left);
                }
                if(deq.right != null){
                    que.Enqueue(deq.right);
                }
            }
            
            if(lastToAdd != null)
                res.Add((int)lastToAdd);
        }
        
        return res;
    }
}