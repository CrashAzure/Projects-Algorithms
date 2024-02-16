public class Solution {
    public bool IsPalindrome(int x) {
        string s = x.ToString();
        char[] c = s.ToCharArray();
        Array.Reverse(c);
        string s1 = new string(c);
        return s == s1;
    }
}