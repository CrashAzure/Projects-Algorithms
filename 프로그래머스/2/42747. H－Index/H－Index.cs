using System;

public class Solution {
    public int solution(int[] citations) {

        Array.Sort(citations);
        int answer = 0;
        
        for(int i = 0; i < citations[citations.Length - 1]; i ++ )
        {
            int t2 = 0;
            for(int j = 0; j< citations.Length; j++)
            {
                if(citations[j] >= i)
                {
                    t2++;
                }    
            }
            
            if(t2 >= i) answer = i;
        }
        
        
        
        
        return answer;
    }
}