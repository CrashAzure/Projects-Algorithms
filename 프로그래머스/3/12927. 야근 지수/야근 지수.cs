using System;
using System.Linq;

public class Solution {
    public long solution(int n, int[] works) {
        long answer = 0;
        long index = works.Length - 1;
        
        if(works.Sum() <= n) return answer;
        
        Array.Sort(works);
        
        for(int i = 0; i < n; i++)
        {
            index = works.Length - 1;
            while(index > 0 && works[index] <= works[index - 1])
                index--;
            
            works[index]--;
        }
        
        
        foreach(var i in works)
        {
            answer += i * i;
        }
        
        
        return answer;
    }
}