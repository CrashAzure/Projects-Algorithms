using System;
using System.Collections.Generic;

public class Solution {
    // 보조 컨테이너 벨트는 스택 구조
    // 컨테이너 벨트는 큐 구조
    public int solution(int[] order) {
        int answer = 0;
        int pointer = 0;
        Stack<int> s = new Stack<int>();        
        
        
        for(int i = 0; i < order.Length; i++)
        {
            bool pass = false;
            if(s.Count != 0 && s.Peek() == order[i])
            {
                s.Pop();
                answer++;
                pass = true;
                continue;
            }
            while(true)
            {
                if(pointer > order.Length) break;
                if(order[i] != pointer)
                {
                    s.Push(pointer);
                    pointer++;
                }
                else
                {
                    pointer++;
                    answer++;
                    pass = true;
                    break;
                }
            }
            if(!pass) break;
        }
        
        
        return answer;
    }
}