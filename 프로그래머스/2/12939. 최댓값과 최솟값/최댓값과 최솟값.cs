using System;

public class Solution {
    public string solution(string s) {
        string answer = "";
        
        string[] c = s.Split(' ');
    
        int max = int.Parse(c[0].Replace("-", ""));
        
        if(c[0][0] == '-') max *= -1;
        int min = max;

        for(int i = 1; i < c.Length; i++)        
        {
            int curr = int.Parse(c[i].Replace("-", ""));
            if(c[i][0] == '-') curr *= -1;
            if(max < curr) max = curr;
            if(min > curr) min = curr;
        }
        
        answer = min.ToString() + " " + max.ToString();
        
        return answer;
    }
}