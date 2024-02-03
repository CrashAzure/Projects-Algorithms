using System;

class Solution 
{
    public int solution(int n) 
   {
        string s1 = Convert.ToString(n, 2);
        string s2 = "";
        int c1 = s1.Length - s1.Replace("1", "").Length;
        int c2 = -1;
        
        int n2 = n;
        
        while(c1 != c2)
        {
            n2++;
            s2 = Convert.ToString(n2, 2);
            c2 = s2.Length - s2.Replace("1", "").Length;
        }
        
        return n2;
    }
}