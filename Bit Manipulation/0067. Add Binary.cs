public class Solution {
    public string AddBinary(string a, string b) {
        var sb = new StringBuilder();
        int i = a.Length - 1, j = b.Length - 1;
        int carry = 0;
        while(i >= 0 || j >= 0){ // Any of the strings still has digits
          int cur = carry;
          if(i >= 0) // Add the digit if it exists
            cur += a[i--] - '0';
          if(j >= 0)
            cur += b[j--] - '0';

          sb.Append(cur % 2); // Append only the LSB
          carry = cur / 2; // Update the carry
        }

        if(carry != 0) // If there is a carry left over
          sb.Append(carry);
        // C# stupid reverse string from StringBuilder
        return new string(sb.ToString().Reverse().ToArray());
    }
}