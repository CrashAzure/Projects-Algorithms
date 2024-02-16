using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public HashSet<int> hs = new HashSet<int>(); // 소수리스트
    
    public int solution(string numbers) {
        int answer = 0;

        bool[] boolArr = new bool[numbers.Length]; 
        char[] charArr = new char[numbers.Length]; 

        for (int i = 0; i < numbers.Length; i++)
        {
            charArr[i] = numbers[i]; // 숫자 조각
        }
        
        MakeNums(boolArr, charArr, "");
        
        foreach(var i in hs)
        {
            if(CheckNum(i)) answer++;
        }
        
        return answer;
    }
    
    private void MakeNums(bool[] boolArr, char[] charArr, string str)
    {
        if (str.Length == boolArr.Length)
            return;

        for (int i = 0; i < boolArr.Length; i++)
        {
            if (boolArr[i])
                continue;
            // 중복 방지
            boolArr[i] = true;
            MakeNums(boolArr, charArr, str + charArr[i]);
            // 사용 후 풀어주기
            boolArr[i] = false;

            int num = int.Parse(str + charArr[i]);
            hs.Add(num);
        }
    }
   
    
    private bool CheckNum(int num)
    {
        if(num == 0 || num == 1) return false;
        
        for(int i = 2; i <= Math.Sqrt(num); i++)
        {
            if(num % i == 0) return false;
        }
        
        return true;
    }
}