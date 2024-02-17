using System;

// 길이와 높이가 n인 삼각형
// 꼭짓점부터 반시계 방향으로 달팽이를 채운다.
// 리턴 배열은 위에서 부터 내려오면서 배열을 가짐
// 횟수와 각 배열의 순차점들이 어떠한 상관 관계를 가지고 있는가?
// 그냥 다 만들고 배열에 넣자?
// 1 2 4 7 8 9 10 6 3 5
// 1 2 3 4 5 6 7 8 9 10
// 아무리 봐도 다른 패턴은 없어 보인다...
// 그냥 순서대로 해보자.
// 내려갈 때는 현재 인덱스 + 현재 행의 크기
// 올라갈 때는 현재 인덱스 - 현재 행의 크기
// 옆으로 갈때는 현재 인덱스 ++
// 방향을 트는 것은 n n-1 n-2 ... 이후
public class Solution {
    public int[] solution(int n) {
         int max = GetFactorial(n);
            int[] answer = new int[max];
            int count = n - 1;
            int dir = 1; // 1 이면 내려가고 0이면 옆으로 가고 -1이면 올라간다.
            int colCount = 1; // 내려가면 +1 옆으로 가면 +0 올라가면 -1 (+dir)
            int num = 2; // 배열에 담을 값
            int index = 0;
            answer[0] = 1;

            while (num <= max)
            {
                if (count == 0)
                {
                    n--;
                    count = n;
                    // 방향 전환
                    dir--;
                    if (dir < -1) dir = 1;
                }

                if (dir == 0)
                {
                    index++;
                }
                else
                {
                    index += colCount * dir;
                }

                colCount += dir;

                answer[index] = num;
                num++;
                count--;
            }

            return answer;
    }
    
    int GetFactorial(int n)
    {
        if(n == 1)
            return 1;
        
        return n + GetFactorial(n - 1);
    }
}