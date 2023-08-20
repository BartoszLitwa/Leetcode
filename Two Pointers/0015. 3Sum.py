class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        res = []
        nums.sort()

        for i, a in enumerate(nums):
            if i > 0 and a == nums[i - 1]:
                continue

            l, r = i + 1, len(nums) - 1
            while l < r:
                sum = nums[i] + nums[l] + nums[r]
                if sum < 0:
                    l += 1
                elif sum > 0:
                    r -= 1
                else: # Found
                    res.append([nums[i], nums[l], nums[r]])
                    l += 1
                    # Skip duplicate values
                    while nums[l] == nums[l - 1] and l < r:
                        l += 1

        return res