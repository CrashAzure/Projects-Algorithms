using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        List<int> temp = new List<int>();
        List<int> answer = new List<int>();
        int[] t = new int[progresses.Length];
        
        
        for(int i = 0; i < t.Length; i++)
        {
            int j = (int)Math.Ceiling((float)(100 - progresses[i]) / speeds[i]);
             
            
            if(temp.Count == 0 || temp[temp.Count - 1] < j) 
            {
                answer.Add(1);
                temp.Add(j);
            }
            else
            {
                answer[answer.Count - 1]++;
            }
            
        }
        
        
        return answer.ToArray();
    }
}