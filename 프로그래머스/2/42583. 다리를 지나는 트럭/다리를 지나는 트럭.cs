using System;
using System.Collections.Generic;

public class Solution {
    // 각 트럭은 다리의 길이 초 이후 도착
    // 중량 이하로 유지
    // 기본적인 다리의 자료구조는 큐 -> 큐에 무게가 아닌 인덱스를 두면 편할 것 같다.
    // 조건문 거치고 진입 당시 시간을 기록해두면 나가는 타이밍을 알게됨. (딕셔너리)
    public int solution(int bridge_length, int weight, int[] truck_weights) {
        int answer = 0;
        int pivot = 0;
        int currWeight = 0;
        int time = 1;
        
        Queue<int> q = new Queue<int>();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        
        for(int i = 0; i < truck_weights.Length; i++)
        {
            dict.Add(i, 0);
        }
        dict[pivot] = time;
        q.Enqueue(pivot);
        currWeight += truck_weights[pivot];
        //Console.WriteLine("Enqueue : " + truck_weights[pivot]+ " Time : " + time);
        pivot++;
        
        while(true)
        {   
            // 진입
            if(pivot < truck_weights.Length && weight >= currWeight + truck_weights[pivot])
            {
                //Console.WriteLine("Enqueue : " + truck_weights[pivot]+ " Time : " + time); 
                dict[pivot] = time;
                q.Enqueue(pivot);
                currWeight += truck_weights[pivot];
                pivot++;
            }
            
            if(q.Count == 0) break;
            
            if(q.Count != 0 && time - dict[q.Peek()] >= bridge_length - 1)
            {
                int outPivot = q.Dequeue();
                currWeight -= truck_weights[outPivot];
                //Console.WriteLine("Weight : " + currWeight + " Truck Weight : " + truck_weights[outPivot] + " Time : " + time);
            }
            
            time++;
        }
        
        return time;
    }
}