using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
        int answer = 1;
        
        List<string> t = new List<string>();
        List<int> s = new List<int>();
        
        for(int i = 0; i < clothes.GetUpperBound(0) + 1; i++)
        {
            bool find = false;
            for(int j = 0; j < t.Count; j ++)
            {
                if(clothes[i, 1] == t[j])
                {
                    s[j]++;
                    find = true;
                    break;
                }
            }
            
            if(!find)
            {
                t.Add(clothes[i, 1]);
                s.Add(1);
            }
        }
        
        
        foreach(var tt in s)
        {
            answer *= tt + 1;
        }
        
        // 최소 한개의 의상
        answer--;
        return answer;
    }
}