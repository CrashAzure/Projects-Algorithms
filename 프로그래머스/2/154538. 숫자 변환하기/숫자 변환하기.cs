using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int x, int y, int n) {
        int answer = 1;
        if(x == y) return 0;
        List<int> l1 = new List<int>();
        HashSet<int> hs = new HashSet<int>();
        l1.Add(x);
        
        // 3 개의 경우의 수를 모두 연산
        // 리스트에 저장 후 체크
        // 원하는 답이 없다면 진행
        // 모든 경우의 수가 y 보다 크다면 종료 (실패)
        // 모든 경우의 수 그냥 넣으면 시간초과
        while(l1.Count != 0)
        {
            for(int i = 0; i < l1.Count; i++)
            {
                if(l1[i] > y) continue;
                
                hs.Add(l1[i] + n);
                hs.Add(l1[i] * 2);
                hs.Add(l1[i] * 3);
            }
            
            foreach(var l in hs)
            {
                if(l == y) return answer;
            }
            
            l1.Clear();
            l1 = new List<int>(hs);
            hs.Clear();
            answer++;
        }

        return -1;
    }
}