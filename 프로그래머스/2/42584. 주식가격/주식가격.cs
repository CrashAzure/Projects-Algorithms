using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] prices) {
        int[] answer = new int[prices.Length];
        
        Dictionary<int, int> d = new Dictionary<int, int>();
        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();

        for(int i = 0; i < prices.Length; i++)
        {
            Stack<int> s = new Stack<int>();
            /*
            foreach( var dd in d)
            {
                if(dd.Value <= prices[i]) 
                {
                    answer[dd.Key]++;
                }
                else 
                {
                    s.Push(dd.Key);
                }
            }
     
            while(s.Count != 0)
            {
                d.Remove(s.Pop());
            }
            
            d.Add(i, prices[i]);
            */
            
            for(int j = 0; j < l1.Count; j++)
            {
                if(l1[j] <= prices[i]) 
                {
                    answer[l2[j]]++;
                }
                else 
                {
                    s.Push(j);
                }
            }
            
            while(s.Count != 0)
            {
                int index = s.Pop();
                l1.RemoveAt(index);
                l2.RemoveAt(index);
            }
            
            l1.Add(prices[i]);
            l2.Add(i);
            
            answer[i] = 1;
        }
        
        foreach( var dd in l2)
        {
             answer[dd]--;
        }
        
        answer[answer.Length - 1] = 0;
        
        return answer;
    }
}