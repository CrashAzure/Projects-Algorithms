using System;
using System.Collections.Generic;

public class Solution {
        public int answer = 0;
    public int solution(string word) {
        List<string> l = new List<string>();
        char[] c = new char[]{'A', 'E', 'I', 'O', 'U'};
        Function("", word, c, l, 1);
        return l.Count - 1;
    }
    
    void Function(string currStr, string target, char[] charArr, List<string> l, int length)
    {
        if(l.Count != 0 && l[l.Count - 1] == target) return;
        l.Add(currStr);
        if(currStr.Length == length)
        {
            Console.WriteLine(currStr);
            return;
        }
        
        if(length == 6) return;
        
        for(int i = 0; i < charArr.Length; i++)
        {
            Function(currStr + charArr[i], target, charArr, l, length + 1);
        }
    }
}