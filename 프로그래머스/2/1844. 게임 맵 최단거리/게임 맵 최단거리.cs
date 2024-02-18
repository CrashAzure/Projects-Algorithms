
using System;
using System.Collections.Generic;

class Solution {
    // 1 : open, 0 : closed
    public int solution(int[,] maps) {
        int answer = 0;
        int width = maps.GetLength(1);
        int height = maps.GetLength(0);

        int[] mX = new int[]{ 0, 0, 1, -1 };
        int[] mY = new int[]{ 1, -1, 0, 0 };
        
        Queue<int[]> q = new Queue<int[]>();
        int[,] countArr = new int[maps.GetLength(0),maps.GetLength(1)];
        int[] curr = new int[2];

        maps[0, 0] = 0;
        countArr[0, 0] = 1;
        q.Enqueue(curr);
        
        while(q.Count != 0)
        {
            curr = q.Dequeue();
            
            if(curr[0] == height - 1 && curr[1] == width - 1)
            {
                return countArr[curr[0], curr[1]];
            }
            
            int count = countArr[curr[0], curr[1]];
            
            for(int i = 0; i < 4; i++)
            { 
                int x = curr[0] + mX[i];
                int y = curr[1] + mY[i];
                if( x < 0 || x >= height
                  || y < 0 || y >= width) continue;
                
                if(maps[x, y] == 1) 
                {
                    maps[x, y] = 0;
                    countArr[x, y] = count + 1;
                    q.Enqueue(new int[]{x, y});
                }
            }
            
        }
        return -1;
    }
    
}