using System;

public class Solution {
    public int[] solution(int n, long left, long right) {
        int[] answer = new int[right - left + 1];
       
        for(long i = left; i <= right; i++)
        {
            answer[i - (int)left] = (int)(i % n <  i / n ? i / n + 1 : i % n + 1);
        }
        return answer;
    }
}