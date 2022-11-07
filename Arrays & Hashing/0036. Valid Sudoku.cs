public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rows = new Dictionary<int, HashSet<int>>();
        var cols = new Dictionary<int, HashSet<int>>();
        var subBoxes = new Dictionary<
            Tuple<int, int>, HashSet<int>>();
        
        for(int r = 0; r < board.Length; r++){
            for(int c = 0; c < board[r].Length; c++){
                var tup = (r / 3, c / 3).ToTuple();
                var digit = board[r][c];
                
                if(digit == '.') // If this cell is empty skip it
                    continue;
                
                if(subBoxes.ContainsKey(tup)){ // Check if given subBox already exists
                    if(subBoxes[tup].Contains(digit)) // Check if it contains the digit
                        return false; // If it does, return false
                } else {
                    subBoxes.Add(tup, new HashSet<int>()); // If we already do not have the subBox, add it
                }
                subBoxes[tup].Add(digit); // Add the digit to the subBox
                
                // Do the same for rows and columns
                if(rows.ContainsKey(r)){
                    if(rows[r].Contains(digit))
                        return false;
                } else {
                    rows.Add(r, new HashSet<int>());
                }
                rows[r].Add(digit);
                
                if(cols.ContainsKey(c)){
                    if(cols[c].Contains(digit))
                        return false;
                } else {
                    cols.Add(c, new HashSet<int>());
                }
                cols[c].Add(digit);
            }
        }
        
        return true;
    }
}