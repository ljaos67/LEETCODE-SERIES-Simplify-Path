public class Solution {
    public string SimplifyPath(string path) {
        Stack<string> stack = new Stack<string>();
        StringBuilder temp = new StringBuilder();
        
        for (int i = 0; i <= path.Length; i++) {
            if (i < path.Length && path[i] != '/') {
                temp.Append(path[i]);
            } else {
                // Only process when we hit a slash or end of string to ensure we've collected a full directory name
                if (temp.Length > 0) {
                    string dir = temp.ToString();
                    temp.Clear(); // Clear the StringBuilder for the next directory name
                    
                    if (dir == "..") {
                        if (stack.Count > 0) stack.Pop();
                    } else if (dir != ".") {
                        stack.Push(dir);
                    }
                }
            }
        }

        if (stack.Count == 0) return "/";

        StringBuilder res = new StringBuilder();
        foreach (string dir in stack) {
            res.Insert(0, "/" + dir);
        }

        return res.ToString();
    }
}
