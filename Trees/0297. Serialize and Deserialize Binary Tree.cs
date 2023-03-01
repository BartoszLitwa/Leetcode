/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var strBuilder = new StringBuilder();
        Helper(root);
        return strBuilder.ToString();

        void Helper(TreeNode root){
            if(root == null) {
                strBuilder.Append("N,");
                return;
            }
            strBuilder.Append(root.val + ",");
            Helper(root.left);
            Helper(root.right);
        }
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        var split = data.Split(",");
        int index = 0;
        return Helper();

        TreeNode Helper(){
            if(split[index] == "N"){
                index++;
                return null;
            }

            var node = new TreeNode(int.Parse(split[index]));
            index++;
            node.left = Helper();
            node.right = Helper();
            return node;
        }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));