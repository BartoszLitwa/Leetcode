public class Solution {
    private int[] parent;
    private int[] rank;
    // Union Find algo
    public int[] FindRedundantConnection(int[][] edges) {
        parent = new int[edges.Length + 1]; // Make it easier to access
        rank = new int[edges.Length + 1]; // 0-th item will be not used
        for(int i = 0; i < edges.Length + 1; i++){ // Populate
            parent[i] = i;
            rank[i] = 1;
        }

        for(int i = 0; i < edges.Length; i++){
            if(!Union(edges[i][0], edges[i][1])) //Find the first that is already connected
                return edges[i];
        }

        return new int[] {};
    }

    private int FindRoot(int n){
        int p = parent[n];

        while(p != parent[p]){ // Until p is not its own parent - root
            p = parent[parent[p]];
        }
        return p;
    }

    private bool Union(int n1, int n2){
        int p1 = FindRoot(n1), p2 = FindRoot(n2);

        if(p1 == p2) // It has the same root - it is already connected
            return false;

        if(rank[p1] > rank[p2]){ // p1 has more nodes connected
            rank[p1] += rank[p2]; // Merge the number of nodes connected
            parent[p2] = p1; // Set parent of p2 to p1
        } else { // Opposite
            rank[p2] += rank[p1];
            parent[p1] = p2;
        }
        return true;
    }
}