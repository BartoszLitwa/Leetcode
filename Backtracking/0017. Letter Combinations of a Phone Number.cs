public class Solution {
    private IList<string> res;
    private string digits;
    private string[] map = new string[]{
        "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
    };

    public IList<string> LetterCombinations(string digits) {
        res = new List<string>();
        this.digits = digits;
        if(string.IsNullOrEmpty(digits))
            return res;

        var cur = "";
        DFS(0, cur);

        return res;
    }

    private void DFS(int pos, string cur){
        if(pos >= digits.Length){
            res.Add(cur);
            return;
        }

        for(int i = 0; i < map[digits[pos] - 2 - '0'].Length; i++){
             cur += map[digits[pos] - 2 - '0'][i];
             DFS(pos + 1, cur);
             cur = cur.Remove(cur.Length - 1); // Remove last char
        }
    }
}