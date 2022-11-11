public class Solution {
    public bool IsValid(string s) {
        if(s.Length % 2 != 0)
            return false; // We can not have odd number of brackets
        
        var stack = new Stack<char>();
        var mapping = new Dictionary<char, char>() { 
            {'(', ')'}, {'{', '}'}, {'[', ']'} 
        };
        
        for(int i = 0; i < s.Length; i++){
            if(mapping.ContainsKey(s[i])) // Open bracket
                stack.Push(s[i]); // Push open bracket
            // if stack is empty than we cannot map open bracket to any close bracket
            else if(stack.Count == 0 || s[i] != mapping[stack.Pop()]) // close bracket is different than popped
                    return false;
        }
        
        return stack.Count == 0; // If we not found the close bracket then it is not valid
    }
}