public class Solution {
    public string Multiply(string num1, string num2) {
        int n1 = num1.Length;
        int n2 = num2.Length;
        int[] products = new int[n1 + n2]; // The maximum length of the product is the sum of the lengths of the two numbers

        for (int i = n1 - 1; i >= 0; i--) { // Start from the end
            for (int j = n2 - 1; j >= 0; j--) { // Start from the end
                int p1 = i + j; // Position of the first digit
                int p2 = p1 + 1; // Position of the second digit
                int sum = (num1[i] - '0') * (num2[j] - '0') + products[p2]; // Sum of the two digits + carry value

                products[p1] += sum / 10; // Add the carry value to the first digit
                products[p2] = sum % 10; // Add the second digit
            }
        }

        StringBuilder sb = new StringBuilder();
        foreach(int num in products) { // Remove leading zeros
            if (!(sb.Length == 0 && num == 0)) { // If the string is empty and the number is 0, do not add it
                sb.Append(num);
            }
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}