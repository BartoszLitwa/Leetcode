public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        var adj = new Dictionary<string, IList<string>>();
        // Sort the tickets by the first element, then by the second element
        tickets = tickets.OrderBy(t => t[0]).ThenBy(t => t[1]).ToList();

        foreach(var ticket in tickets){ // Create adjacency list
            if(adj.ContainsKey(ticket[0]))
                adj[ticket[0]].Add(ticket[1]);
            else
                adj.Add(ticket[0], new List<string>{ ticket[1] });
        }

        var res = new List<string>{ "JFK" }; // Always start from JFK

        Helper(res[0]); // Start from JFK

        return res;

        bool Helper(string from){
            if(res.Count == tickets.Count + 1) // We have found a path
                return true;
            if(!adj.ContainsKey(from)) // We have reached a dead end
                return false;

            var copy = new List<string>(adj[from]); // Create copy
            for(int i = 0; i < copy.Count; i++){
                string to = adj[from][i]; // Get the next destination
                adj[from].RemoveAt(i); // Remove the next destination
                res.Add(to); // Add the next destination to the path

                if(Helper(to)) // If we have found a path, return true
                    return true;

                adj[from].Insert(i, to); // Revert changes
                // We have to remove the last item 
                res.RemoveAt(res.Count - 1); // Revert changes
            }

            return false;
        }
    }
}