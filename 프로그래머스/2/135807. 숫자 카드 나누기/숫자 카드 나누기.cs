using System;
using System.Collections.Generic;

public class Solution {
    // 카드를 절반으로 나눠 갖는다
    // 가장 큰 양의 정수 a 가 리턴 값
    // A 를 철수 B 를 영희
    // 서로의 공약수 리스트를 제거해준 뒤 남은 공약수 중 최대
    // A에서 B를 지우거나 B에서 A를 지우거나 두 조건 중 하나를 만족하는 값
    public int solution(int[] arrayA, int[] arrayB) {
        int answer = 0;
        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();
        List<int> l3 = new List<int>();
        List<int> l4 = new List<int>();
        
        Array.Sort(arrayA);
        Array.Sort(arrayB);
        
        GetNums(arrayA[0], l1);
        l1.Sort();
        GetNums2(arrayA, l1, l3);
        
        GetNums(arrayB[0], l2);
        l2.Sort();
        GetNums2(arrayB, l2, l4);
        
        
        int r1 = GetMaxNum(arrayB, l3);
        int r2 = GetMaxNum(arrayA, l4);
        
        answer = Math.Max(r1, r2);
        
        return answer;
    }
    
    void GetNums(int min, List<int> l)
    {
        for(int i = 1; i <= Math.Sqrt(min); i++)
        {
            if(min % i == 0) 
            {
                l.Add(i);
                if(i != min / i) l.Add(min / i);
            }
        }
    }
    
    void GetNums2(int[] array, List<int> l1, List<int> l2)
    {
        for(int i = 0; i < l1.Count; i++)
        {
            bool isPass = true;
            for(int j = 0; j < array.Length; j++)
            {
                if(array[j] % l1[i] != 0)
                {
                    isPass = false;
                    break;
                }
            }
            
            if(isPass) l2.Add(l1[i]);
        }
    }
    
    int GetMaxNum(int[] array, List<int> l)
    {
        for(int i = l.Count - 1; i >= 0; i--)
        {
            bool isPass = true;
            for(int j = 0; j < array.Length; j++)
            {
                if(array[j] % l[i] == 0)
                {
                    isPass = false;
                    break;
                }
            }
            
            if(isPass) return l[i];
        }
        
        return 0;
    }
}
