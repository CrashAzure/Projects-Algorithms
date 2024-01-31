using System;
using System.Collections.Generic;

public class Solution {
    public bool solution(string s) {
        bool answer = true;
        Stack<int> ss = new Stack<int>();
        
        for(int i = 0; i < s.Length; i ++)
        {
            if(s[i] == '(') ss.Push(1);
            else if(s[i] == ')' && ss.Count == 0) return false;
            else ss.Pop();
        }
        

        
        answer = ss.Count == 0;

        return answer;
    }
}