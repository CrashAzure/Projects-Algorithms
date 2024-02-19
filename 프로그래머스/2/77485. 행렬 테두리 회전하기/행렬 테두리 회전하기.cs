using System;
using System.Collections.Generic;

public class Solution {
    
    // 행과 열의 크기
    // 1 ~ rows * columns 숫자가 순서대로 적혀져 있다. (1, 2, 3 ... , rows * columns)
    // 직사각형 범위를 선택, 시계방향으로 한칸 회전.
    // 그 회전에 의해 위치가 바뀐 숫자들 중 가장 작은 숫자들을 순서대로 배열에 담아 리턴
    // dir 0 우 1 하 2 좌 3 상
    public int[] solution(int rows, int columns, int[,] queries) {
        int[] answer = new int[] {};
        int[,] table = new int[rows, columns];
        List<int> result = new List<int>();
        int[] xy1 = new int[2];
        int[] xy2 = new int[2];
        int[] pos = new int[2];
        
        int count = 1;
        // 초기 테이블
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                table[i,j] = count;
                count++;
            }
        }
        
        // 입력 기반 회전
        for(int i = 0; i < queries.GetLength(0); i++)
        {
            xy1[0] = queries[i, 0] - 1;
            xy1[1] = queries[i, 1] - 1;
            xy2[0] = queries[i, 2] - 1;
            xy2[1] = queries[i, 3] - 1;
            
            // 시작점
            xy1.CopyTo(pos, 0);
            

            // 값들의 배열
            int[] values = new int[2 * (xy2[0] - xy1[0] + xy2[1] - xy1[1])];
            
            
            // 처음 값 저장
            values[0] = table[pos[0], pos[1]];
            
            // dir 0 우 1 하 2 좌 3 상
            int dir = 0;
            int c = 1;
            while(c < values.Length)
            {
                // 범위 밖으로 나가기 전에 방향 전환 (시계방향)
                GetDirection(pos, xy1, xy2, ref dir);
                
                // 방향에 맞춰 좌표 수정
                if(dir == 0)
                {
                    pos[1]++;
                }
                else if(dir == 1)
                {
                    pos[0]++;
                }
                else if(dir == 2)
                {
                    pos[1]--;
                }
                else
                {
                    pos[0]--;
                }
                
                values[c] = table[pos[0], pos[1]];
                table[pos[0], pos[1]] = values[c - 1];
                c++;
            }
            
            // 회전 종료
            table[xy1[0], xy1[1]] = values[values.Length - 1];
            
            // 최소값 등록
            Array.Sort(values);
            result.Add(values[0]);
        }
        
        answer = result.ToArray();
        
        return answer;
    }
    
    // 범위 밖으로 나가기 전에 방향 전환 (시계방향)
    void GetDirection(int[] pos, int[] xy1, int[] xy2, ref int dir)
    {
        switch(dir)
        {
            case 0:
                if(pos[1] + 1 > xy2[1]) dir++;
                break;
            case 1:
                if(pos[0] + 1 > xy2[0]) dir++;
                break;
            case 2:
                if(pos[1] - 1 < xy1[1]) dir++;
                break;
            case 3:
                if(pos[0] - 1 < xy1[0]) dir++;
                break;
        }
    }
}