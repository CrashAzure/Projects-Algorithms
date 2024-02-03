using System;
using System.Collections.Generic;

public class Solution {
    public Dictionary<int, long> d = new Dictionary<int, long>();
    
    public long solution(int n) {
        // All 1
        long answer = 1;
        
        // 1, 2, 3, 5, 
        answer = F(n);
        answer %= 1234567;
        return answer;
    }
    
    long F(int n)
    {
        if(n <= 2) return n;
        if(d.ContainsKey(n)) return d[n];
        
        long r = (F(n - 1) + F(n - 2)) % 1234567;
        
        d.Add(n, r);
        
        return r;
    }
}