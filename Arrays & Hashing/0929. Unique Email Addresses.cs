public class Solution {
    public int NumUniqueEmails(string[] emails) {
        var set = new HashSet<string>();

        for(int i = 0; i < emails.Length; i++){
            var split = emails[i].Split("@"); // split[0] = local, split[1] = domain
            // Remove . from local and everything after +
            set.Add($"{split[0].Replace(".", "").Split("+")[0]}@{split[1]}");
        }

        return set.Count;
    }
}