public class Solution {
    // Imprtant each operator is for the last 2 values on the stack
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        var operators = new List<string>() {"+", "-", "*", "/"};
        for(int i = 0; i < tokens.Length; i++){
            if(operators.Contains(tokens[i])){ // we found operator
                // We want to pop last 2 integers from the stack
                var lastPop = stack.Pop(); // order of the values is important for - & /
                // push the result to the stack
                stack.Push( tokens[i] switch {
                    "+" => stack.Pop() + lastPop,
                    "-" => stack.Pop() - lastPop,
                    "*" => stack.Pop() * lastPop,
                    "/" => stack.Pop() / lastPop
                }); 
            } else { // Integer
                stack.Push(Int32.Parse(tokens[i]));
            }
        }
        
        return stack.Pop(); // Pop the last value
    }
}