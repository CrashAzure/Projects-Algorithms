using System;
    using System.Collections.Generic;

    class Solution
    {
        public class Pos
        {
            public int y;
            public int x;
            public int count; // 이동 횟수

            public Pos(int y, int x, int count)
            {
                this.y = y;
                this.x = x;
                this.count = count;
            }
        }

        public int solution(int[,] maps)
        {
            // maps를 방문배열로 활용 (방문 : 0, 미방문 : 1)
            var dirY = new int[4] { 0, 0, 1, -1 };
            var dirX = new int[4] { 1, -1, 0, 0 };
            var queue = new Queue<Pos>();

            // 시작좌표
            queue.Enqueue(new Pos(0, 0, 1));
            maps[0, 0] = 0;
           
            // BFS
            while (queue.Count != 0)
            {
                // 현재 위치
                Pos currPos = queue.Dequeue();
                
                // dirX, dirY를 이용해 현재 위치에서 이동 가능한 4방향을 나타냄
                for (int i = 0; i < 4; i++)
                {
                    // 이동하려는 위치
                    Pos movePos = new Pos(currPos.y + dirY[i], currPos.x + dirX[i], currPos.count + 1);

                    // 배열 범위 범어남 (게임 맵을 벗어남)
                    if (movePos.y < 0 || movePos.y >= maps.GetLength(0) ||
                       movePos.x < 0 || movePos.x >= maps.GetLength(1))
                        continue;

                    // 적 진영에 도착
                    if (movePos.y == maps.GetLength(0) - 1 &&
                       movePos.x == maps.GetLength(1) - 1)
                        return movePos.count;

                    // 벽이거나 이미 탐색된 길
                    if (maps[movePos.y, movePos.x] == 0)
                        continue;

                    maps[movePos.y, movePos.x] = 0; // 방문처리
                    queue.Enqueue(movePos); // 다음 탐색 대상
                }
            }

            return -1;
        }
    }

/*
using System;
using System.Collections.Generic;

class Solution {
    public int solution(int[,] maps) {
        int answer = 0;
        int width = maps.GetLength(1);
        int height = maps.GetLength(0);

        // 1 : open, 0 : closed
        int[,] visited = new int[maps.GetLength(0),maps.GetLength(1)];
        int[] mX = new int[]{1, 0, -1, 0};
        int[] mY = new int[]{0, 1, 0, -1};
        Array.Copy(maps, visited, visited.Length);
        
        Stack<int[]> s = new Stack<int[]>();
        int[] curr = new int[2];
        int[] d = new int[2] {maps.GetLength(0) - 1,maps.GetLength(1) - 1};
        int l = 0;
        int count = 0;
     
        
        s.Push(curr);
        visited[0, 0] = 0;
        
        foreach(var i in visited)
        {
            if(i == 1) l++;
        }
        
        
        while(l <= 0 || s.Count != 0)
        {
            bool opened = false;
            
            for(int i = 0; i < 4; i++)
            {
                if(curr[0] + mX[i] < 0|| curr[0] + mX[i] >= height
                  ||curr[1] + mY[i] < 0|| curr[1] + mY[i] >= width) continue;
                
                if(visited[curr[0] + mX[i], curr[1] + mY[i]] == 1) 
                {
                    curr[0] += mX[i];
                    curr[1] += mY[i];
                    opened = true;
                    break;
                }
            }
            
            if(opened)
            {
                visited[curr[0], curr[1]] = 0;
                s.Push(curr);
                l--;
            }
            else
            {
                curr = s.Pop();
            }
            
            if(curr[0] == d[0] && curr[1] == d[1])
            {
                return s.Count;
            }
            
        }
        return -1;
    }
}
*/