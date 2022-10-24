public class Solution {
    public bool IsIsomorphic(string s, string t) {
        int n = s.Length;
        // 256 ascii characters size * 2
        int[] m1 = new int[512];
        
        for(int i = 0; i < n; i++){
            // If number of these character is different
            if(m1[s[i]] != m1[t[i] + 256])
                return false;
            
            m1[s[i]] = m1[t[i] + 256] = i + 1;
        }
        
        return true;
    }
    
    public bool IsIsomorphic3(string s, string t) {
        int n = s.Length;
        // 256 ascii characters size
        int[] m1 = new int[256], m2 = new int[256];
        
        for(int i = 0; i < n; i++){
            // If number of these character is different
            if(m1[s[i]] != m2[t[i]])
                return false;
            
            m1[s[i]] = i + 1;
            m2[t[i]] = i + 1;
        }
        
        return true;
    }
    
    public bool IsIsomorphic2(string s, string t){
        var alph = new List<char>();
        var alph2 = new List<char>();
        var iso = new int[s.Length];
        var iso2 = new int[t.Length];
        for(int i = 0; i < s.Length; i++){
            if(!alph.Contains(s[i])){
                alph.Add(s[i]);
            }
            if(!alph2.Contains(t[i])){
                alph2.Add(t[i]);
            }
            
            iso[i] = alph.IndexOf(s[i]);
            iso2[i] = alph2.IndexOf(t[i]);
            
            if(iso[i] != iso2[i]){
                return false;
            }
        }
        
        return true;
    }
}