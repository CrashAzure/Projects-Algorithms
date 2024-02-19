using System;

public class Solution {
    // 2 3 4 미터 지점에 좌석
    // 균형을 맞출 수 있다면 두 사람은 시소 짝꿍
    // 몇 쌍이 존재할 수 있는지 리턴하라.
    // 일단 짝꿍인지는 앉은 좌석 미터 * 무게가 서로 같으면 충족
    // 현재 요소가 이후의 요소와 비교하였을 때
    // 2배가 넘어가면 스탑
    // 만약 다음 무게가 같으면 스킵
    public long solution(int[] weights) {
        long answer = 0;
        int count = 0;
        Array.Sort(weights);
        for(int i = 0; i < weights.Length - 1; i++)
        {
            int gap = 1;
            if(i != 0 && weights[i] == weights[i - 1]) 
            {
                count--;
                answer += count;
                continue;
            }
            count = 0;
            //Console.Write(i);
            while((i + gap) < weights.Length && (float)weights[i + gap] / weights[i] <= 2)
            {
                int min = weights[i];
                int max = weights[i + gap];
                
                if(min * 4 == max * 3 || min * 2 == max || min * 3 == max * 2 || min == max)
                {
                    //Console.Write(" "+ min +" "+ max);
                    count++;
                }
                gap++;
            }
            
            answer += count;
            
            //Console.WriteLine(" ");
            
        }
        
        
        return answer;
    }
}