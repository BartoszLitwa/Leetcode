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
    public int GoodNodes(TreeNode root) {
        return Dfs(root, root.val);
    }

    public int Dfs(TreeNode node, int max){
        if(node == null)
            return 0;

        var res = node.val >= max ? 1 : 0;
        var maxVal = Math.Max(max, node.val);
        return res + Dfs(node.left, maxVal) + Dfs(node.right, maxVal);
    }

    // BFS solution
    public int GoodNodes2(TreeNode root) {
        int res = 0;
        if(root == null)
            return res;

        var que = new Queue<(TreeNode, int)>();
        que.Enqueue((root, root.val));
        while(que.Count > 0){
            var len = que.Count;
            while(len-- > 0){
                var tuple = que.Dequeue();
                var deq = tuple.Item1;
                if(deq == null)
                    continue;

                if(deq.val >= tuple.Item2){ // Check if previously seen max is less than current node's value
                    res++;
                }

                if(deq.left != null){ // Enqueue left node with max value seen so far
                    que.Enqueue((deq.left, Math.Max(deq.val, tuple.Item2)));
                }
                if(deq.right != null){ // Enqueue right node with max value seen so far
                    que.Enqueue((deq.right, Math.Max(deq.val, tuple.Item2)));
                }
            }
        }

        return res;
    }
}