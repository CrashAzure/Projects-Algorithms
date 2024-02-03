using System;

using System.Collections.Generic;

public class Solution {
    public List<long> pL = new List<long>();
    public int solution(int n, int k) {
        int answer = 0;

        string s = MakeNum(n, k);
        string[] t = s.Split('0');
        
        foreach(var tt in t)
        {
            if(long.TryParse(tt, out long i) && CheckP(i))
            {
                 answer++;
            }
               
        }
        
        return answer;
    }
    
    string MakeNum(int n, int k)
    {
        string r = "";
        List<int> l = new List<int>();
        while(n > 0)
        {
            
            l.Add(n % k);
            n = n / k;
        }
        
        for(int i = l.Count - 1; i >= 0; i--)
        {
            r += l[i].ToString();
        }
        
        return r;
    }
    
    bool CheckP(long n)
    {
        if(n == 1) return false;
        for(int i = 2; i <= Math.Sqrt(n); i++)
        {
            if(n == 2 || n == 3) break;
            if(n % i == 0) return false;
        }
        pL.Add(n);
        return true;
    }
}