using System;
using System.Collections.Generic;
public class Solution {
    // 직사각형 격자 형태의 지도
    // X(바다) 1 ~ 9 자연수
    // 숫자는 무인도
    // 상하좌우로 연결된 경우 하나의 무인도
    // 리턴 값은 각 섬에서 최대 며칠씩 머무를 수 있는지 오름차순의 배열
    // 뭉쳐진 무인도를 고려해야한다.
    
    // "X591X"
    // "X1X5X"
    // "X231X"
    // "1XXX1"
    // DFS 재귀
    // 현재 인덱스 기준 상하좌우로 값이 X가 아닌 곳으로 이동 더하기 연산 시 방문 했다 판단.
    // X 행 Y 열
    int[] dirX = new int[]{ 1, 0, -1, 0};
    int[] dirY = new int[]{ 0, 1, 0, -1};
    
    public int[] solution(string[] maps) {
        int[] answer = new int[]{ -1 };
        bool[,] visited = new bool[maps.Length,maps[0].Length];
        List<int> result = new List<int>();
        
        for(int i = 0; i < maps.Length; i++)
        {
            for(int j = 0; j < maps[0].Length; j++)
            {
                if(visited[i, j] == true || maps[i][j] == 'X') continue;
                int sum = Function(i, j, maps, visited, result);
                if(sum != 0) result.Add(sum);
            }
        }

        if(result.Count != 0)
        {
            result.Sort();
            answer = result.ToArray();    
        }
        
        return answer;
    }
    
    int Function(int posX, int posY, string[] maps, bool[,] visited, List<int> result)
    {
        visited[posX, posY] = true;
        int sum = 0;
        for(int i = 0; i < 4; i++)
        {
            int x = posX + dirX[i];
            int y = posY + dirY[i];
            
            // 배열 밖
            if(x >= maps.Length || y >= maps[0].Length
              || x < 0 || y < 0) continue;
            
            // 이미 방문
            if(visited[x, y] == true) continue;
            string s = maps[x];
            // 상하좌우 중 하나가 무인도인 경우
            if(s[y] != 'X') sum += Function(x, y, maps, visited, result);
        }
        string s1 = maps[posX];
        if(int.TryParse(s1[posY].ToString(), out int n)) sum += n; 
        
        return sum;
    }
}