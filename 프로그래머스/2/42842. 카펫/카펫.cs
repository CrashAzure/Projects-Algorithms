using System;

public class Solution {
    public int[] solution(int brown, int yellow) {
        int[] answer = new int[2];
        int t = brown + yellow;
        int max = 1;
        double sqrt = Math.Sqrt(t);
        
        // 노란 카펫이 반으로 줄 때마다 갈색 카펫의 요구 수치가 낮아진다.
        // 갈색 카펫의 갯수 = 노란카펫 / n * 3 + 2 * n + 4
        

        for(int n = 1; n < sqrt; n ++)
        {
            if(yellow % n == 0)
            {
                if(brown == yellow * 2 / n + 2 * n + 4)
                {
                    max = yellow / n;
                    break;
                }
            }
        }
        
        answer[0] = max + 2;
        answer[1] = t / answer[0];
        
        return answer;
    }
}