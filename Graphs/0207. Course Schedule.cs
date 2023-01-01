public class Solution {
    private Dictionary<int, List<int>> preMap;
    private int numCourses;
    private int[][] prerequisites;

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        preMap = new Dictionary<int, List<int>>();
        this.numCourses = numCourses;
        this.prerequisites = prerequisites;

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
        for(int i = 0; i < numCourses; i++){
            if(!DFS(i, visitSet)) // Check if this course is finishable
                return false;
        }
        return true;
    }

    private bool DFS(int course, HashSet<int> visitSet){
        if(visitSet.Contains(course)) // Check if its already checked
            return false;
        // Does not have any prerequisitses or otherwise it is already check that it is possible
        else if(preMap[course] == null) 
            return true;

        visitSet.Add(course);
        for(int i = 0; i < preMap[course].Count; i++){
            if(!DFS(preMap[course][i], visitSet)) // Check if this prerequisite is finishable 
                return false;
        }
        preMap[course] = null; // Reset the prerequisites since we checked that it is possible to finish course
        visitSet.Remove(course);
        return true;
    }
}