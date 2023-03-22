public class Solution {
    public int CalPoints(string[] operations) {
        var stack = new Stack<int>();
        var res = 0;
        for(int i = 0; i < operations.Length; i++){
            if(operations[i] == "+"){
                var first = stack.ElementAt(0);
                var second = stack.ElementAt(1);
                stack.Push(first + second);
                res += first + second;
            } else if(operations[i] == "D"){
                var peek = stack.Peek();
                stack.Push(peek * 2);
                res += peek * 2;
            } else if(operations[i] == "C"){
                var pop = stack.Pop();
                res -= pop;
            } else {
                var integer = int.Parse(operations[i]);
                stack.Push(integer);
                res += integer;
            }
        }

        return res;
    }
}