using System;
using System.Linq;
using System.Collections.Generic;


public class Solution {
    
    public int[] solution(string[] operations) {
        int[] answer = new int[2];
        
        List<int> l = new List<int>();
        
        foreach(var o in operations)
        {
            int[] t = Gen(o);
            if(t[0] == 1)
            {
                l.Add(t[1]);
            }
            else if(t[0] == 2 && l.Count != 0)
            {
                if(t[1] == -1)
                {
                    l.Remove(l.Min());
                }
                else if(t[1] == 1)
                {
                    l.Remove(l.Max());
                }
            }
        }
        if(l.Count != 0)
        {
            answer[0] = l.Max();
            answer[1] = l.Min();    
        }

        return answer;
    }
    
    // 1, 2
    // 0 fail
    private int[] Gen(string op)
    {
        int[] result = new int[2];
        
        string[] t = op.Split(' ');
        
        if(t[0] == "I")
        {
            result[0] = 1;
        }
        else if(t[0] == "D")
        {
            result[0] = 2;
        }
        result[1] = int.Parse(t[1]);
        
        return result;
    }
}