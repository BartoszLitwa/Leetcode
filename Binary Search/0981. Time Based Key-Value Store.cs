public class TimeMap {
    private Dictionary<string, IList<(int, string)>> map;

    public TimeMap() {
        map = new Dictionary<string, IList<(int, string)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!map.ContainsKey(key)){ // If we do not already store this key
            map.Add(key, new List<(int, string)>());
        }
        map[key].Add((timestamp, value)); // Add the value
    }
    
    public string Get(string key, int timestamp) {
        if(!map.ContainsKey(key) || map[key].Count == 0)
            return "";
        
        string res = "";
        int left = 0, right = map[key].Count - 1;
        while(left <= right){
            int mid = (left + right) / 2;
            
            if(map[key][mid].Item1 == timestamp){ //Valid value - equal to timestamp
                return map[key][mid].Item2;
            } else if(map[key][mid].Item1 < timestamp){ // less
                res = map[key][mid].Item2; // Our closest value so far
                left = mid + 1;
            } else { // greater
                right = mid - 1;
            }
        }
        
        return res;
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */