public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();
        res.Add(new List<int>{ 1 }); // add the first row
        for(int i = 1; i < numRows; i++){ // iterate through each row
            res.Add(new List<int>()); // add a new row
            res[i].Add(1); // add the first element
            for(int j = 1; j < i; j++){ // iterate through each element
                // add the sum of the two elements above
                res[i].Add(res[i - 1][j - 1] + res[i - 1][j]);
            }

            res[i].Add(1); // add the last element
        }

        return res;
    }
}