using System;

public class Solution {
    public int[] solution(string s) {
        int[] answer = new int[2];
        
        while(s != "1")
        {
            string t = s.Replace("0", "");
            answer[1] += s.Length - t.Length;
            s = Convert.ToString(t.Length, 2);
            answer[0]++;
        }
        
        return answer;
    }
}