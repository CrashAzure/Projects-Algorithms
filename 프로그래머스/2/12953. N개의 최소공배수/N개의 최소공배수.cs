using System;
using System.Collections.Generic;

public class Solution {
    
    public int solution(int[] arr) {
        int answer = arr[0];
        
        
        for(int i = 1; i < arr.Length; i++)
        {
            answer = LCM(answer, arr[i]);
        }
        
        
        
        return answer;
    }
    
    int LCM(int n1, int n2)
    {
       return n1 * n2 / GCD(n1, n2) ;
    }
    
    int GCD(int n1, int n2)
    {
        if(n2 == 0) return n1;
        else return GCD(n2, n1 % n2);
    }
}