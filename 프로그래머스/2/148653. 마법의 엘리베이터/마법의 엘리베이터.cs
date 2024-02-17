using System;

public class Solution {
    // -1 +1 -10 +10 -100 +100.. 절댓값이 10^c 버튼
    // 지하로는 내려가지 못한다
    // 최소한의 버튼
    // 복잡해졌는데 그냥 자리수 마다 리스트로 계산해놓고 올려주는 식으로 하는게 가독성이 좋을 것 같다.
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
