using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int n) {
        int answer = 0;
        
        Dictionary<int, int> d = new Dictionary<int, int>();
        
        d.Add(0, 0);
        d.Add(1, 1);
        
        for(int i = 2; i <= n; i++)
        {
            if(d.ContainsKey(i)) continue;

            d.Add(i, (d[i - 1] + d[i - 2]) % 1234567);
        }
        answer = d[n];
        return answer % 1234567;
    }
}