public class Node {
    public int key, val;
    public Node prev, next;
    
    public Node(int _key, int _val, Node _prev, Node _next){
        key = _key;
        val = _val;
        prev = _prev;
        next = _next;
    }
}

public class LRUCache {
    private int capacity;
    private Dictionary<int, Node> dict;
    private Node lru, mru;

    public LRUCache(int _capacity) {
        capacity = _capacity;
        dict = new Dictionary<int, Node>();
        lru = new Node(-1, -1, null, null);
        mru = new Node(-1, -1, null, null);
        
        // Link the lru and mru
        lru.next = mru;
        mru.prev = lru;
    }
    
    public int Get(int key) {
        if(dict.TryGetValue(key, out var node)){
            // We want to update it to the most recent
            Remove(node);
            Insert(node);
            
            return node.val;
        }
        
        return -1;
    }
    
    public void Put(int key, int value) {
        if(dict.TryGetValue(key, out var node)){ // If we already have it remove it
            Remove(node);
            dict[key].val = value; // Update the value
        } else {
            dict.Add(key, new Node(key, value, null, null));
        }
        
        Insert(dict[key]);
        
        if(dict.Count > capacity){ // Remove the LRU
            var nextLRU = lru.next;
            Remove(nextLRU);
            dict.Remove(nextLRU.key);
        }
    }
    
    // remove the node from the list
    public void Remove(Node node){
        Node prev = node.prev, next = node.next;
        prev.next = next;
        next.prev = prev;
    }
    
    // Insert the new rmu
    public void Insert(Node node){
        Node prev = mru.prev, next = mru;
        node.prev = prev;
        node.next = mru;
        prev.next = next.prev = node;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */