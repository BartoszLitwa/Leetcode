public class Solution {
    private Dictionary<int, List<int>> preMap;
    private int numCourses;
    private int[][] prerequisites;
    private List<int> res;

    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        preMap = new Dictionary<int, List<int>>();
        this.numCourses = numCourses;
        this.prerequisites = prerequisites;
        res = new List<int>();

        // Courses that will have the null do not have any prerequisites
        for(int i = 0; i < numCourses; i++){ // Prepare for all possible courses and its prerequisites
            preMap.Add(i, null); // Set it to null 
        }

        for(int i = 0; i < prerequisites.Length; i++){ // only map for given courses
            // Map the course i to its prerequisites
            preMap[prerequisites[i][0]] = (preMap[prerequisites[i][0]] ?? new List<int>()) 
            .Concat(prerequisites[i].Skip(1).ToList()).ToList(); // Merge multiples prerequisites for 1 course
        }

        var visitSet = new HashSet<int>();
        var cycleSet = new HashSet<int>();

        for(int i = 0; i < numCourses; i++){
            if(!DFS(i, visitSet, cycleSet)) // Cannot find the solution
                return new int[] {};
        }

        return res.ToArray();
    }

    private bool DFS(int course, HashSet<int> visitSet, HashSet<int> cycleSet){
        if(cycleSet.Contains(course))
            return false;
        else if(visitSet.Contains(course))
            return true;

        cycleSet.Add(course); // Add it to the cycle so we know we are not checking it twice
        if(preMap[course] != null){ // Make sure there are any prerequisites to check
            foreach(int pre in preMap[course]){
                if(!DFS(pre, visitSet, cycleSet))
                    return false;
            }
        }
        
        cycleSet.Remove(course);
        visitSet.Add(course); // We have checked every prerequisite
        res.Add(course);
        return true;
    }
}