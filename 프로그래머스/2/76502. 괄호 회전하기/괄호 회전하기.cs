using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string s) {
        int answer = 0;
        if(s.Length % 2 == 1) return answer;
        // 회전은 쉬프트를 뜻하는 것 같다.
        // 올바른 문자열인 경우는
        // 1. 제일 안쪽 문자열은 올바라야 한다.
        // 2. 제일 안쪽 문자열이 올바른 경우 이를 제거하고 반복한다.
        // 재귀 함수를 사용하면 될 듯 하다.
        // 어떻게 제일 안쪽 문자열을 알 수 있는가?
        // 제일 안쪽이 아니라 바로 옆에 있는 괄호가 내 짝이 맞는지를 확인하자.
        // 임시 카운트가 문자열 길이 / 2 면 함수 종료 및 성공 넘어가면 실패
        // 쉬프트의 카운트는 문자열의 길이
        
        char[] cArr = s.ToCharArray();
        List<char> cList = cArr.ToList();

        // shift count
        for(int i = 0; i < s.Length; i++)
        {
            if(CheckString(cList))
            {
                answer++;
            }
            
            cList.Add(cList[0]);
            cList.RemoveAt(0);
        }

        return answer;
    }
    
    private bool CheckString(List<char> cList)
    {
        int count = 0;
        int i = 0;
        List<char> temp = new List<char>();
        
        foreach(var c in cList)
        {
            temp.Add(c);
        }
        
        
        while(i < temp.Count - 1)
        {
            if(temp[i] == '(' && temp[i + 1] == ')'
              ||temp[i] == '{' && temp[i + 1] == '}'
              ||temp[i] == '[' && temp[i + 1] == ']')
            {
                // Found
                temp.RemoveAt(i + 1);
                temp.RemoveAt(i);
                // Start Again
                i = 0;
                if(temp.Count == 0) break;
                continue;
            }
            i++;
        }
        return temp.Count == 0;
    }
}

