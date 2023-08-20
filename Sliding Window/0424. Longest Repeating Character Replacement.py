class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        count = {}
        res = 0
        l = 0
        maxF = 0
        for r in range(len(s)):
            count[s[r]] = 1 + count.get(s[r], 0)
            maxF = max(maxF, count[s[r]]) # trick to save scanning the hashMap each time

            while (r - l + 1) - maxF > k: # out of replacements
                count[s[l]] -= 1
                l += 1

            res = max(res, r - l + 1)

        return res