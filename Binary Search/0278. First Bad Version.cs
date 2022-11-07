/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int left = 1;
        int right = n;
        
        while(left <= right){
            int mid = left + (right - left) / 2;
            if(!IsBadVersion(mid)){
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return left;
    }
    
    public int FirstBadVersion2(int n) {
        int left = 1;
        int right = n;
        
        while(left <= right){
            int mid = left + (right - left) / 2;
            var res = IsBadVersion(mid);
            var prev = IsBadVersion(mid - 1);
            if(res && !prev){
                return mid;
            } else if(res && prev){
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
}