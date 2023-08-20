class Solution:
    def isValid(self, s: str) -> bool:
        closeToOpen = {')': '(', ']': '[', '}': '{'}
        stack = []

        for c in s:
            if c in closeToOpen:
                if stack and stack[-1] == closeToOpen[c]:
                    stack.pop()
                else:
                    return False
            else: # open brackets
                stack.append(c)
        # stack has to be empty at the end
        return True if not stack else False
