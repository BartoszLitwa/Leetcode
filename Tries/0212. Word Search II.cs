public class Solution {
    public class TrieNode{
        public Dictionary<char, TrieNode> children;
        public bool isWord;

        public TrieNode(){
            children = new Dictionary<char, TrieNode>();
            isWord = false;
        }

        public void AddWord(string word){
            var curNode = this;
            foreach(char c in word){ // Add each letter to the trie
                if(!curNode.children.ContainsKey(c)){ // If it doesn't exist
                    curNode.children.Add(c, new TrieNode());
                }
                curNode = curNode.children[c]; // Move to the next node
            }
            curNode.isWord = true; // Mark the last node as a word
        }
    }

    public IList<string> FindWords(char[][] board, string[] words) {
        var root = new TrieNode();
        foreach(var w in words){ // Add all words to the trie
            root.AddWord(w);
        }

        int rows = board.Length, cols = board[0].Length;
        var res = new HashSet<string>(); // To eliminate duplicates
        var visited = new HashSet<(int row, int col)>();
        var directions = new (int row, int col)[4] { // Directions to check
            (-1, 0), (1, 0), (0, -1), (0, 1)
        };
        
        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){ // Start from every cell
                DFS(r, c, root, "");
            }
        }
        return res.ToList(); // Return the result

        void DFS(int row, int col, TrieNode node, string curWord){
            if(row < 0 || col < 0 || row >= rows || col >= cols ||
                visited.Contains((row, col)) || // Already visited
                !node.children.ContainsKey(board[row][col])) // Not in trie
                return;

            visited.Add((row, col)); // Mark as visited
            node = node.children[board[row][col]]; // Move to the next node
            curWord += board[row][col]; // Add the letter to the word

            if(node.isWord){ // If it's a word
                res.Add(curWord);
            }

            foreach(var dir in directions){ // Check in every direction
                DFS(row + dir.row, col + dir.col, node, curWord);
            }

            visited.Remove((row, col)); // Cleanup after
        }
    }
}