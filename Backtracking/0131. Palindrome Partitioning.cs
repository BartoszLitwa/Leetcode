public class Solution {
    private IList<IList<string>> res;
    private string word;

    public IList<IList<string>> Partition(string s) {
        word = s;
        res = new List<IList<string>>();
        var part = new List<string>();

        DFS(0, part);

        return res;
    }

    private void DFS(int startIndex, IList<string> part){
        var partition = part.ToList();
        if(startIndex == word.Length) {
            res.Add(partition);
            return;
        }

        for(int i = startIndex; i < word.Length; i++){
            // java's substring(startIndex, endIndex)      C#'s Substring(startIndex, SubLength)
            var sub = word.Substring(startIndex, i - startIndex + 1);   
            if(IsPalindrome(sub)){
                partition.Add(sub);
                DFS(i + 1, partition);
                partition.RemoveAt(partition.Count() - 1);
            }
        }
    }

    private bool IsPalindrome(string str){
        for (int i = 0, j = str.Length - 1; i < j;) {
            if (str[i++] != str[j--]) 
                return false;
        }
        return true;
    }

    private bool IsPalindrome(string s, int start, int end){
        while(start < end){
            if(s[start++] != s[end--]) // Increase start and decrease end
                return false;
        }

        return true;
    }
}