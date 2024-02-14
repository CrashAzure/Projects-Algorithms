using System;
using System.Collections.Generic;

// 자신보다 크면서 가장 가까이 있는 뒷 수
// 단순 2중 for 문 - 시간 초과
// 끝 인덱스부터 스택에 담으면서 피킹
public class Solution {
    public int[] solution(int[] numbers) {
        int[] answer = new int[numbers.Length];
        Stack<int> s = new Stack<int>();
        answer[numbers.Length - 1] = -1;
        s.Push(numbers[numbers.Length - 1]);

        for(int i = numbers.Length - 2; i >= 0; i--)
        {   
            int temp = -1;
            
            while(s.Count != 0)
            {
                if(s.Peek() > numbers[i])
                {
                    temp = s.Peek();
                    break;
                }
                else 
                    s.Pop();
            }

            answer[i] = temp;
            s.Push(numbers[i]);
        }
        
        return answer;
    }
}