using System;
using System.Collections.Generic;

public class Solution {
    // 초기 두 큐의 크기는 같다.
    // 큐의 특성상 큐 1과 큐 2의 최대 pop and push 횟수는 큐의 크기 만큼이다.
    // 큐 1번의 pop 횟수는 큐 2번의 push 횟수
    // 원소의 크기는 10^9 -> long type
    // 리턴값은 교환의 수
    // 모든 원소의 합 / 2만큼 나눠 가져야함. -> 미리 연산
    // 큰 쪽에서 작은 쪽으로 교환
    public int solution(int[] queue1, int[] queue2) {
        int answer = 0;
        Queue<long> q1 = new Queue<long>();
        Queue<long> q2 = new Queue<long>();
        
        long sum1 = 0;
        long sum2 = 0;
        long total = 0;
 
        for(int i = 0; i < queue1.Length; i++)
        {
            sum1 += queue1[i];
            sum2 += queue2[i];
            q1.Enqueue(queue1[i]);
            q2.Enqueue(queue2[i]);
        }
        
        total = sum1 + sum2;
        
        // 합이 홀수이면 불가능
        if(total % 2 != 0) return -1;
        
        while(sum1 != sum2)
        {
            // 교환할 원소
            long t = 0;
            
            // 큰 쪽에서 작은 쪽으로 교환
            if(sum1 > sum2)
            {
                t = q1.Dequeue();
                q2.Enqueue(t);
                sum1 -= t;
                sum2 += t;
            }
            else if(sum2 > sum1)
            {
                t = q2.Dequeue();
                q1.Enqueue(t);
                sum2 -= t;
                sum1 += t;
            }
            
            answer++;
            
            // 실패
            if(answer > queue1.Length + queue2.Length + 2) return -1;
        }
        
        return answer;
    }
}