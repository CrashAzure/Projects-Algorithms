using System;
using System.Collections.Generic;

public class Solution {
    public int answer = -1;
        
    // DFS
    // 노드 수만큼 bool 배열 준비
    public bool[] visited;
    
    public int solution(int k, int[,] dungeons) {
        visited = new bool[dungeons.GetLength(0)];
        // 재귀함수 (전체 탐색)
        Func(k, dungeons, 0);
        
        
        return answer;
    }
    
    public void Func(int k, int[,] d, int c)
    {
        for(int i = 0; i < d.GetLength(0); i++)
        {
            if(!visited[i]&& d[i, 0] <= k)
            {
                visited[i] = true;
                Func(k - d[i, 1], d, c + 1);
                visited[i] = false;
            }
        }
        
        if(answer < c)
            answer = c;
    }
        
        
        
}