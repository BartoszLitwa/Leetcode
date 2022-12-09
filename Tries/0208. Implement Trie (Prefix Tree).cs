public class TrieNode{
    public Dictionary<char, TrieNode> children;
    public bool endOfWord;

    public TrieNode(){
        children = new Dictionary<char, TrieNode>();
        endOfWord = false;
    }
}

public class Trie {
    private TrieNode root;

    public Trie() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        var curNode = root;
        for(int i = 0; i < word.Length; i++){
            if(!curNode.children.ContainsKey(word[i])){
                curNode.children.Add(word[i], new TrieNode());
            }
            curNode = curNode.children[word[i]];
        }

        curNode.endOfWord = true;
    }
    
    public bool Search(string word) {
        var curNode = root;
        for(int i = 0; i < word.Length; i++){
            if(!curNode.children.ContainsKey(word[i])){
                return false;
            }
            curNode = curNode.children[word[i]];
        }

        return curNode.endOfWord;
    }
    
    public bool StartsWith(string prefix) {
        var curNode = root;
        for(int i = 0; i < prefix.Length; i++){
            if(!curNode.children.ContainsKey(prefix[i])){
                return false;
            }
            curNode = curNode.children[prefix[i]];
        }

        return true;
    }
}

public class Trie {
    private Dictionary<char, IList<string>> dict;

    public Trie() {
        dict = new Dictionary<char, IList<string>>();
    }
    
    public void Insert(string word) {
        var letter = Char.ToLower(word[0]);
        if(!dict.ContainsKey(letter)){
            dict.Add(letter, new List<string>());
        }

        dict[letter].Add(word);
    }
    
    public bool Search(string word) {
        var letter = Char.ToLower(word[0]);
        if(!dict.ContainsKey(letter))
            return false;

        return dict[letter].Any(x => x.ToLower() == word);
    }
    
    public bool StartsWith(string prefix) {
        var letter = Char.ToLower(prefix[0]);
        if(!dict.ContainsKey(letter))
            return false;

        return dict[letter].Any(x => x.ToLower().StartsWith(prefix));
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */