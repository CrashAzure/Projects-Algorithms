using System;

public class Solution {
    // 각 스킬의 최소 인덱스가 순서대로라면 문제가 없어 보인다.
    public int solution(string skill, string[] skill_trees) {
        int answer = 0;
        char[] skills = skill.ToCharArray();
        foreach(var st in skill_trees)
        {
            int[] t = new int[skills.Length];
            
            for(int i = 0; i < skills.Length; i++)
            {
                for(int j = 0; j < st.Length; j++)
                {
                    if(st[j] == skills[i]) 
                    {
                        t[i] = j + 1;
                        break;
                    }
                }
            }
            
            bool isAble = true;
            int temp = -1;
            for(int i = 1; i < t.Length; i++)
            {
                if(!isAble) break;
                
                if(t[i] != 0) 
                {
                    for(int j = 0; j < i; j++)
                    {
                        if(t[j] == 0)
                        {
                            isAble = false;
                            //Console.WriteLine("i :" + i + " j : "+j);
                            //Console.WriteLine("t[j] :" + t[j] + " j : "+j);
                        }
                    }
                }
                
                if(t[i] != 0 && t[i - 1] > t[i]) isAble = false;
            }
            /*
            foreach(var i in t)
            {
                Console.WriteLine(i);
            }
            if(isAble) 
            {
                Console.WriteLine("Possible : " + st);
                answer++;
            }
            else
            {
                Console.WriteLine("Impossible : " + st);
            }
            Console.WriteLine("");
            */
            if(isAble) answer++;
           
        }
        
        
        return answer;
    }
}