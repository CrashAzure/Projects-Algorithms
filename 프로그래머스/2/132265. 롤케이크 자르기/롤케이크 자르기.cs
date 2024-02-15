using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    // 두조각으로 자른다.
    // 각 딕셔너리에 토핑 종류에 따른 개수를 기록
    // 스택
    // 한쪽으로 옮겨주면서 값체크
    public int solution(int[] topping) {
        int answer = 0;
        
        Stack<int> s = new Stack<int>();
        Dictionary<int, int> d1 = new Dictionary<int, int>();
        Dictionary<int, int> d2 = new Dictionary<int, int>();
        
        d2.Add(topping[topping.Length - 1], 1);
        
        
        for(int i = 0; i < topping.Length - 1; i++)
        {
            s.Push(topping[i]);
            if(!d1.ContainsKey(topping[i]))
                d1.Add(topping[i], 1);
            else
                d1[topping[i]]++;
        }
        
        while(s.Count >= 1)
        {
            int v = s.Pop();
            
            d1[v]--;
            
            if(d1[v] == 0) d1.Remove(v);
            
            // 종류만을 기록
            if(!d2.ContainsKey(v)) d2.Add(v, 1);
            
            if(d1.Count == d2.Count) answer++;
            
            // 더 이상 크기가 같을 수 없음
            if(d1.Count < d2.Count) break;
        }
        
        
        
        return answer;
    }
}
