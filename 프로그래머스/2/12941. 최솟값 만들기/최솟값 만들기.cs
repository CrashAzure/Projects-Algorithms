using System;

public class Solution {
    public int solution(int[] A, int[] B) {
        int answer = 0;
        
        // 완전 탐색?
        Array.Sort(A);
        Array.Sort(B);
        Array.Reverse(B);
        
        for(int i = 0; i < A.Length; i++)
        {
            Console.WriteLine("A:"+A[i]+", B:"+B[i]);
            answer+=A[i]*B[i];
        }
        return answer;
    }
}