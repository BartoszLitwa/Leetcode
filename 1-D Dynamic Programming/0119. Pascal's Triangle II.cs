public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var ans = new int[rowIndex + 1];
        ans[0] = ans[rowIndex] = 1; // first and last element are always 1
        long temp = 1; // to avoid overflow
        // nCr = n*(n-1)*(n-2)...(r terms) / 1*2*..........*(r-2)*(r-1)*r
        for(int i = 1,up=rowIndex;i<rowIndex;i++,up--){
            temp = temp * up / i;
            ans[i]=(int)temp;
        }

        return ans;
    }
}