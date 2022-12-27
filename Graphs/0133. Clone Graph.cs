/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    private Dictionary<Node, Node> oldToNew;

    public Node CloneGraph(Node node) {
        oldToNew = new Dictionary<Node,Node>();

        return node == null ? null : DFS(node);
    }

    private Node DFS(Node node){
        if(oldToNew.ContainsKey(node)){
            return oldToNew[node]; // Return copy
        }

        var copy = new Node(node.val);
        oldToNew.Add(node, copy); // Add new copy

        foreach(var n in node.neighbors){ // Populate neihgbours the new copy of node
            copy.neighbors.Add(DFS(n));
        }

        return copy;
    }
}