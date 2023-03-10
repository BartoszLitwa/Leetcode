public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if(!wordList.Contains(endWord))
            return 0;

        var adjList = new Dictionary<string, IList<int>>();
        adjList.Add(beginWord, new List<int>()); // Create adjaceny list
        for(int w = 0; w < wordList.Count(); w++){ // For each word
            var sb = new StringBuilder(wordList[w]);
            for(int i = 0; i < sb.Length; i++){ // For each char
                var tempChar = sb[i];
                sb[i] = '*'; // Replace only one char with wildcard
                var pattern = sb.ToString();
                sb[i] = tempChar; // Restore char
                if(adjList.ContainsKey(pattern)){ // For this pattern
                    adjList[pattern].Add(w); // Add word index
                } else {
                    adjList.Add(pattern, new List<int>{ w });
                }
            }
        }

        var visited = new HashSet<int>();
        var que = new Queue<int>();
        que.Enqueue(-1); // Add beginWord = -1
        int result = 1;
        while(que.Count > 0){ // BFS
            var len = que.Count; // Get current level size
            for(int w = 0; w < len; w++){
                var pop = que.Dequeue(); // Pop word index
                var word = pop == -1 ? beginWord : wordList[pop]; // Get word
                if(word == endWord) // Found endWord
                    return result; // Return result

                var sb = new StringBuilder(word);
                for(int i = 0; i < sb.Length; i++){ // For each char
                    var tempChar = sb[i];
                    sb[i] = '*';
                    var pattern = sb.ToString(); // Replace only one char with wildcard
                    sb[i] = tempChar;
                    if(!adjList.ContainsKey(pattern)) // If no pattern found - skip
                        continue;
                    
                    foreach(var adjIndex in adjList[pattern]){ // For each adjacent word
                        if(visited.Contains(adjIndex))
                            continue;
                        // Add to queue and visited
                        que.Enqueue(adjIndex);
                        visited.Add(adjIndex);
                    }

                }
            }
            result++; // Increment result
        }
        return 0; // Not found
    }
}