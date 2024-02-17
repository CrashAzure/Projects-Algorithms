using System;
using System.Collections.Generic;

public class Solution {
    // 비내림차순 정렬된 수열
    // 시작 인덱스 부터 마지막 인덱스까지의 부분 수열이여야한다. (붙어 있어야 한다)
    // 부분 수열의 합은 k 여야 한다.
    // 합이 k인 부분 수열이 여러 개인 경우 길이가 짧은 수열을 찾는다.
    // 가장 짧은 수열이 여러 개라면 시작 인덱스가 나은 경우를 선택한다.
    // 리턴 값은 시작 인덱스, 끝 인덱스
    class T : IComparable<T>
    {
        public int start;
        public int end;
        public int length;
        
        public T(int s, int e, int l)
        {
            start = s;
            end = e;
            length = l;
        }
        
        public int CompareTo(T other)
        {
            if(length > other.length) return 1;
            else if(length < other.length) return -1;
            else 
            {
                if(start < other.start) return -1;
                else if(start < other.start) return 1;
                else return 0;
            }
        }

    }
    
    public int[] solution(int[] sequence, int k) {
        int[] answer = new int[2];
        List<T> l = new List<T>();
        int left = 0;
        int right = 0;
        int sum = 0;
        
        while (right <= sequence.Length && left <= right)
        {
            if (sum > k)
            {
                if(left < sequence.Length) sum -= sequence[left];
                left++;
                continue;
            }
            else if (sum < k)
            {
                if(right < sequence.Length) sum += sequence[right];
                right++;
                continue;
            }
            else
            {
                //Console.WriteLine("left :" + left + " right : " + right);
                l.Add(new T(left, right - 1, right - left));
                if(left < sequence.Length) sum -= sequence[left];
                left++;
            }
        }
        
        
        l.Sort();
        answer[0] = l[0].start;
        answer[1] = l[0].end;
        return answer;
    }
}