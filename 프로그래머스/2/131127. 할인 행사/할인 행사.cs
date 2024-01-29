using System;

public class Solution {
    public int solution(string[] want, int[] number, string[] discount) {
        int answer = 0;
        string[] temp = new string[10];
        
        for(int i = 0; i < discount.Length - 9; i++)
        {
            bool found = true;
            Array.Copy(discount, i, temp, 0, 10);

            for(int j = 0; j < want.Length; j++)
            {
                int count = 0;
                foreach(var t in temp)
                {
                    if(t ==  want[j]) count++;
                }
                
                if(count < number[j]) 
                {
                    found = false;
                    continue;
                }
            }
            
            if(found)
            {
                answer++;
            }
            
            
        }
        
        
        
        return answer;
    }
}