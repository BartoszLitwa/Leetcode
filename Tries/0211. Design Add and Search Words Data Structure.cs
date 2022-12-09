public class TrieNode {
    public Dictionary<char, TrieNode> children;
    public bool endOfWord;

    public TrieNode() {
        children = new Dictionary<char, TrieNode>();
        endOfWord = false;
    }
}

public class WordDictionary {
    private TrieNode root;

    public WordDictionary() {
        root = new TrieNode();
    }
    
    public void AddWord(string word) {
        var cur = root;
        for(int i = 0; i < word.Length; i++){
            if(!cur.children.ContainsKey(word[i])){
                cur.children.Add(word[i], new TrieNode());
            }
            cur = cur.children[word[i]];
        }

        cur.endOfWord = true;
    }
    
    public bool Search(string word) {
        return Dfs(word, root);
    }

    private bool Dfs(string word, TrieNode node){
        var cur = node;
        for(int i = 0; i < word.Length; i++){
            if(word[i] == '.'){ // Check for every possible node letter
                foreach(var tn in cur.children.Values){
                    if(Dfs(word.Substring(i + 1), tn)) // Only return true when we found it
                        return true;
                }

                // Any possible node path is invalid
                return false;
            }
            else if(cur.children.ContainsKey(word[i])){
                cur = cur.children[word[i]];
            } else {
                return false;
            }
        }

        return cur.endOfWord;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */