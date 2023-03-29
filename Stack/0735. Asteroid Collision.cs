public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var stack = new Stack<int>();
        for(int i = 0; i < asteroids.Length; i++){
            while(stack.Count > 0 && asteroids[i] < 0 && stack.Peek() > 0){
                var diff = stack.Peek() + asteroids[i];
                if(diff < 0){ // asteroids[i] wins
                    stack.Pop();
                } else if(diff > 0){
                    asteroids[i] = 0;
                } else { // diff == 0
                    stack.Pop();
                    asteroids[i] = 0;
                }
            }

            if(asteroids[i] != 0){
                stack.Push(asteroids[i]);
            }
        }

        return stack.Reverse().ToArray();
    }
}