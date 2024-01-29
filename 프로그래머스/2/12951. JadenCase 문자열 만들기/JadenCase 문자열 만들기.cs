using System;
using System.Text;

public class Solution {
    public string solution(string s) {
        string answer = "";
        s = s.ToLower();
        
        char[] t = s.ToCharArray();
        t[0] = Char.ToUpper(t[0]);
        for(int i = 1; i < t.Length; i++)
        {
            if(t[i-1] == ' ') t[i] = Char.ToUpper(t[i]);
        }
        
        answer = new String(t);
        
        return answer;
    }
}