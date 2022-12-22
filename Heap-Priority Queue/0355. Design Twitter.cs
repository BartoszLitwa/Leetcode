public class Twitter {
    private int time;
    private Dictionary<int, IList<int[]>> tweetMap; // userId -> [time, tweetId]
    private Dictionary<int, HashSet<int>> followMap; // userId -> HashSet of followeeId

    public Twitter() {
        time = 0;
        tweetMap = new Dictionary<int, IList<int[]>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        var val = new int[2] {time--, tweetId};
        if(tweetMap.ContainsKey(userId)){
            tweetMap[userId].Add(val); // Decrement time
        } else {
            tweetMap.Add(userId, new List<int[]>() {val});
        }
    }
    
    public IList<int> GetNewsFeed(int userId) {
        var res = new List<int>();
        var sort = new SortedList<int, int[]>(); // time - tweetId - followeeId, next index

        // Techincally in this problem users follow themselves
        if(!followMap.ContainsKey(userId)) // Check if this user follows anyone
            Follow(userId, userId); // Dumb and it is not explained in the question directly

        foreach(int followee in followMap[userId]){ // For each follower
            if(!tweetMap.ContainsKey(followee)) // Check if this user has posted anything
                continue;

            var index = tweetMap[followee].Count - 1;
            var tweet = tweetMap[followee][index];
            // Add the time and tweet for it to be sorted
            sort.Add(tweet[0], new int[3] {tweet[1], followee, index - 1} ); 
        }

        while(sort.Count > 0 && res.Count < 10) { // Continue until we have all
            var item = sort.Values[0];
            var key = sort.Keys[0];
            sort.RemoveAt(0); // Heap pop

            res.Add(item[0]); // Add the tweetId
            if(item[2] < 0) // If next index is invalid
                continue;

            var tweet = tweetMap[item[1]][item[2]]; // Get the next tweet from that person
            // Heap push
            sort.Add(tweet[0], new int[3] {tweet[1], item[1], item[2] - 1}); // Add it to the list
        }

        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(followMap.ContainsKey(followerId)){
            followMap[followerId].Add(followeeId);
        } else {
            followMap.Add(followerId, new HashSet<int>() {followeeId});
        }
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(followMap.ContainsKey(followerId) && followMap[followerId].Contains(followeeId)){
            followMap[followerId].Remove(followeeId);
            if(followMap[followerId].Count == 0){ // If this person do not longer have any followers
                followMap.Remove(followerId);
            }
        }
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */