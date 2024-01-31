using System;
using System.Collections.Generic;

class Solution
{
    public int[] solution(int n, string[] words)
    {
        int[] answer = new int[2];
        string prevWord = "";
        List<string> already = new List<string>();
        
        for(int i = 0; i < words.Length; i++)
        {
            bool fail = i != 0 && words[i][0] != prevWord[prevWord.Length - 1];
            foreach(var a in already)
            {
                if(a == words[i]) 
                {
                    fail = true;
                    break;
                }
            }
            
            if(fail)
            {
                
                answer[0] = i % n + 1;
                answer[1] = i / n + 1;
                break;
            }
            
            prevWord = words[i];
            already.Add(prevWord);
        }
        
        
        return answer;
    }
}