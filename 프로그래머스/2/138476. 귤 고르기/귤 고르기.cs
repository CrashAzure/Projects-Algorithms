using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int k, int[] tangerine) {
        int answer = 0;
        Dictionary<int, int> d = new Dictionary<int, int>();
        
        foreach(var t in tangerine)
        {
            if(!d.ContainsKey(t)) d.Add(t, 1);
            else d[t]++;
        }
        
        List<int> l = new List<int>();
        
        foreach(var v in d)
        {
            l.Add(v.Value);
        }
        l.Sort();
        
        for(int i = l.Count - 1; i >= 0; i--)
        {
            if(k > 0) 
            {
                k -= l[i];
                answer++;
            }
            else break;
        }
        return answer;
    }
}