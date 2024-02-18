using System;
using System.Collections.Generic;

public class Solution {
    // 트리 구조
    // 송전탑 1을 최상위 부모 노드로 가정
    // 트리 구조의 특성 상 하나의 간선을 끊을 경우
    // 해당 노드의 자식 노드의 개수 + 1의 개수를 총량으로 가진다 (분리된 트리2)
    // 구해진 분리된 트리의 총량을 전체 총량에서 빼준 값이 트리 1. (n - a)
    // 송전탑 개수의 차이는 n - a - a의 절대값
    // 따라서 송전탑 개수의 차이만을 알기 위해선 굳이 간선을 하나 지우고 트리를 만들 필요는 없다.
    // 자식 노드를 모두 구해야하는데, 양방향 간선이기 때문에
    // 앞일 때 뒤일 때를 모두 고려하여 선택한다.
    // 말단 노드까지 탐색. -> dfs
    public int answer = 0;
    public int solution(int n, int[,] wires) {
        answer = n;
        // 키 값은 송전탑의 번호, 리스트는 자식 노드들의 리스트
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        // 방문 배열
        bool[] visited = new bool[n];
        int[] childCounts = new int[n];
        
        // 딕셔너리 안 리스트 초기화
        for(int i = 0; i < n; i++)
        {
            childCounts[i] = 1;
            dict.Add(i + 1, new List<int>());
        }
        
        for(int i = 0; i < wires.GetLength(0); i++)
        {
            // 양방향으로 자식 노드를 등록
            dict[wires[i, 0]].Add(wires[i, 1]);
            dict[wires[i, 1]].Add(wires[i, 0]);
        }
        
        Function(1, 1, n, visited, childCounts, dict);
        
        return answer;
    }
    
    void Function(int index, int parent, int max, bool[] visited,
                  int[] childCounts, Dictionary<int, List<int>> dict)
    {
        // 실제 노드의 번호이므로 인덱스는 -1
        visited[index - 1] = true;
        
        // 방문하지 않았다면 탐색
        foreach(var child in dict[index])
        {
            if(visited[child - 1] == false)
                Function(child, index, max, visited, childCounts, dict);
        }
        
        // 모든 자식 노드 탐색 완료 상태
        // n - a - a
        int count = Math.Abs(max - (2 * childCounts[index - 1]));
        // 작은 값을 선택
        answer = Math.Min(answer, count);
        // 부모 노드에 자식 노드의 개수를 더해줌
        childCounts[parent - 1] += childCounts[index - 1];
        
    }
}