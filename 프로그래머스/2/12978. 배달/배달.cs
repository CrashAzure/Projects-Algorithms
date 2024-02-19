using System;
using System.Collections.Generic;

class Solution
{
    // N 개 마을
    // 도로 별 시간은 다르다.
    // 1번에서 출발 - 각 정점으로 가는 최단거리들
    // K 시간 이하로 갈 수 있는 마을의 개수
    // 트리 구조로 만들어도 될 듯 하다.
    // 가중치를 포함해야한다.
    public int solution(int N, int[,] road, int K)
    {
        int answer = 0;
        int[] towns = new int[N];
        Queue<int> q = new Queue<int>();
        
        // 연산 이후에도 K 보다 크다면 어차피 계산되지 않을 큰 값.
        for(int i = 1; i < N; i ++)
        {
            towns[i] = K + 2;
        }
        
        // 1번 시작
        // 계산의 편의를 위해 마을 수는 0부터 시작하는 것처럼 생각
        q.Enqueue(0);
        
        while(q.Count != 0)
        {
            int node = q.Dequeue();
            
            for(int i = 0; i < road.GetLength(0); i ++)
            {
                
                int node1 = road[i, 0] - 1;
                int node2 = road[i, 1] - 1;
                int weight = road[i, 2];
                
                // 만약 첫 번째 노드가 노드 1과 같고
                // 1번에서 노드 1까지의 가중치와 현재 간선의 가중치를 더한 값이
                // 1번에서 노드 2번까지의 가중치보다 작다면
                // 갱신하여준다. (더 짧은 거리)
                // 양방향 간선이므로 반대일 경우도 연산
                if(node == node1 && towns[node2] > weight + towns[node1])
                {
                    towns[node2] = weight + towns[node1];
                    q.Enqueue(node2);
                }
                else if(node == node2 && towns[node1] > weight + towns[node2])
                {
                    towns[node1] = weight + towns[node2];
                    q.Enqueue(node1);
                }
            }
        }
        
        foreach(int n in towns)
        {
            if(n <= K) answer++;
        }
        

        return answer;
    }
}