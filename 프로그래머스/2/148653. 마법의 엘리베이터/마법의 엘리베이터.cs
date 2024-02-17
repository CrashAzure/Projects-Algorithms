using System;

public class Solution {
    // -1 +1 -10 +10 -100 +100.. 절댓값이 10^c 버튼
    // 지하로는 내려가지 못한다
    // 최소한의 버튼
    // 첫째 자리수 부터 1 2 3 4 5 기댓값 1 2 3 4 5
    // 6 부터는 6 7 8 9 10
    public int solution(int storey) {
        int answer = 0;
        string s = storey.ToString();
        
        for(int i = s.Length - 1; i >= -1; i--)
        {
            int r = (int)(storey % Math.Pow(10, s.Length - i));
            int n = r /(int)Math.Pow(10, s.Length - i - 1);

            if (n > 5 || n == 5 && ((int)(storey % Math.Pow(10, s.Length - i + 1) / (int)Math.Pow(10, s.Length - i)) >= 5))
            {
                storey += (int)Math.Pow(10, s.Length - i) - r;
                answer += 10 - n;
            }
            else
            {
                storey -= r;
                answer += n;
            }
        }
        
        return answer;
    }
}