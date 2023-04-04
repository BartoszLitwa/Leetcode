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
    public TreeNode SortedArrayToBST(int[] nums) {
        return Helper(0, nums.Length - 1);
        
        TreeNode Helper(int left, int right){ // Helper function
            if(left > right) // Base case
                return null;

            int mid = (left + right) >> 1; // Get middle index
            var node = new TreeNode(nums[mid]); // Create node
            node.left = Helper(left, mid - 1); // Traverse left
            node.right = Helper(mid + 1, right); // Traverse right
            return node;
        }
    }
}