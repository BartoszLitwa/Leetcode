// Backtracking 
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var stringB = new StringBuilder("", n * 2); // Allocated just enough memory
        var list = new List<string>();
        
        Backtrack(stringB, list, 0, 0, n);
        
        return list;
    }
    
    public void Backtrack(StringBuilder builder, List<string> list, int open, int closed, int n){
        if(open == closed && closed == n){ // Only if we used all closeing and opening brackets
            list.Add(builder.ToString());
            return;
        }
        
        if(open < n){ // If we have less than possible of open brackets add it
            builder.Append("(");
            Backtrack(builder, list, open + 1, closed, n); // Continue building the string with this scenario
            builder.Remove(open + closed, 1); // Remove the appended bracket
        }
        
        if(closed < open){ // If we have less closed brackets than possible just add it
            builder.Append(")");
            Backtrack(builder, list, open, closed + 1, n); // Continue building the string with this scenario
            builder.Remove(open + closed, 1); // Remove the appended bracket
        }
    }
}

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var list = new List<string>();
        
        Backtrack(list, "", n, 0);
        
        return list;
    }
    
    public void Backtrack(List<string> list, string curString, int n, int open){
        if(curString.Length == n * 2){ // Only if we used all closeing and opening brackets
            list.Add(curString);
            return;
        }
        
        if(open < n){ // If we have less than possible of open brackets add it
            Backtrack(list, curString + "(", n, open + 1); // Continue building the string with this scenario
        }
        // We cannot have the close bracket before open
        if((curString.Length - open) < open){ // If we have less closed brackets than possible just add it
            Backtrack(list, curString + ")", n, open); // Continue building the string with this scenario
        }
    }
}