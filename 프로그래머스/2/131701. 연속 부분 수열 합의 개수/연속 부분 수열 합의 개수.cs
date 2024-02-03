using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] elements) {
        int answer = 0;
        
        int[] e = new int[elements.Length * 2];
        HashSet<int> h = new HashSet<int>();
        
        for(int i = 0; i < elements.Length; i++)
        {
            e[i] = elements[i];
            e[elements.Length + i] = elements[i];
        }
        
        for(int i = 0; i < elements.Length; i++)
        {
            int sum = 0;
            for(int j = 0; j < elements.Length; j++)
            {
                sum += e[i + j];
                
                h.Add(sum);
            }
        }
        
        answer = h.Count;

        return answer;
        
    }
    
}