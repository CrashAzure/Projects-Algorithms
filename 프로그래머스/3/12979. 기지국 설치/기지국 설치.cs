using System;
using System.Collections.Generic;

class Solution
{
    public int solution(int n, int[] stations, int w){
        int answer = 0;
        
        List<int> l = new List<int>();
        
        List<int> minL = new List<int>();
        List<int> maxL = new List<int>();
        maxL.Add(0);
        for(int i = 0; i < stations.Length; i++)
        {
            minL.Add(stations[i] - w);
            maxL.Add(stations[i] + w);
            /*
            if(stations[i] - w < 0)minL.Add(0);
            else minL.Add(stations[i] - w);
            if(stations[i] + w > n) maxL.Add(n + 1);
            else maxL.Add(stations[i] + w);
            */
        }
        minL.Add(n + 1);
        /*
        foreach(var wwww in minL)
        {
            Console.WriteLine(wwww);
        }
        
        foreach(var wwww in maxL)
        {
            Console.WriteLine(wwww);
        }
        */
        
        for(int i = 0; i < minL.Count; i++)
        {
            /*
            int min = i < 0 ? 0 : minL[i];
            int max = i >= 1 ? maxL[i - 1] : 0;
            
            if(min < 0) min = 0;
            if(max > n) max = n;
            if(i < minL.Count ) l.Add(min - max - 1);
            else l.Add(maxL[i] > n ? n : maxL[i] - minL[i - 1] - 1);
            */
            int min = minL[i];
            int max = maxL[i];
            
            if(min < 0) min = 0;
            if(max > n) max = n;
            if(minL[i] - maxL[i] - 1 > 0)l.Add(minL[i] - maxL[i] - 1);
            
        }
        
        foreach(var tt in l)
        {
            //Console.WriteLine(tt);
            answer += tt / (2*w + 1);
            if(tt % (2*w + 1) != 0) answer++;
        }

        return answer;
    }
}