using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    // k 개의 수를 제거 했을 때 얻을 수 있는 가장 큰 숫자
    // 현재 자리수와 다음 자리수를 비교하여 작다면 삭제
    // 아니면 다음 인덱스로 탐색
    // 삭제 되었다면 삭제 카운트를 하나 올리고 다시 탐색
    // 만약 배열의 끝까지 도착했다면, 이는 즉 맨 끝에 있는 남은 숫자들이 가장 작다는 뜻
    public string solution(string number, int k)
    {
        StringBuilder sb = new StringBuilder(number);
        int count = 0;
        int index = 0;
        while(count < k)
        {
            while(true)
            {
                // 문자열의 끝쪽이 가장 기댓값이 작은 숫자들
                if(index == sb.Length - 1)
                {
                    sb.Remove(index, 1);
                    index--;
                    break;
                }
                
                // 현재 인덱스가 다음 인덱스보다 기대값이 낮다
                if(sb[index] < sb[index + 1])
                {
                    sb.Remove(index, 1);
                    if(index > 0) index--;
                    break;
                }
                
                index++;
            }
            
            count++;
        }

        return sb.ToString();
    }
    
}