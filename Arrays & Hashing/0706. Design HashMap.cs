public class MyHashMap {
    public class ListNode{
        public int key;
        public int val;
        public ListNode next;
        public ListNode(int key, int val, ListNode next){
            this.key = key;
            this.val = val;
            this.next = next;
        }
    }

    public const int size = 1000;
    private ListNode[] _map;
    public MyHashMap() {
        // Initialize with dummy nodes
        _map = Enumerable.Repeat(new ListNode(-1,-1,null), size).ToArray();
    }
    
    public void Put(int key, int value) {
        var node = _map[key % size]; // First is dummy
        while(node.next != null){
            if(node.next.key == key){ // Update
                node.next.val = value;
                return;
            }

            node = node.next;
        }
        // Add new
        node.next = new ListNode(key, value, null);
    }
    
    public int Get(int key) {
        var node = _map[key % size];
        while(node.next != null){
            if(node.next.key == key)
                return node.next.val;

            node = node.next;
        }
        return -1;
    }
    
    public void Remove(int key) {
        var node = _map[key % size];
        while(node.next != null){
            if(node.next.key == key){
                // Remove the node with given key
                node.next = node.next?.next; // skip the node
                return;
            }
            node = node.next;
        }
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */