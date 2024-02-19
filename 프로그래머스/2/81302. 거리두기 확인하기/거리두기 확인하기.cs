using System;

public class Solution {
    // 파티션이 있는 경우 - 맨해튼 거리에 포함 X
    // P 응시자가 앉아있는 자리
    // O 빈 테이블
    // X 파티션
    // 각 행이 각 대기실
    // 입력을 5x5 행렬로 변환
    // 맨해튼 거리가 2 이하인 경우 12개
    // 존재한다면 가는 경로가 모두 파티션으로 막혀있는지 체크
    public  int[] solution(string[,] places)
    {
        int[] answer = new int[5];
        char[,] room = new char[5, 5];

        // 앞의 4방위는 맨해튼 거리 1
        // 뒤는 맨해튼 거리가 2인 경우의 수
        int[] dirR = new int[] { -1, 0, 0, 1, -1, 1, 1, -1, 0, 0, 2, -2 };
        int[] dirC = new int[] { 0, 1, -1, 0, 1, 1, -1, -1, 2, -2, 0, 0 };
        int roomNumber = 0;

        while (roomNumber < 5)
        {
            room = ChangeData(roomNumber, places);

            // 0 fail 1 success
            int isFail = 1;

            for (int i = 0; i < 25; i++)
            {
                if (isFail == 0) break;
                int r = (int)(i / 5);
                int c = i % 5;

                if (room[r, c] == 'P')
                {
                    for (int j = 0; j < 12; j++)
                    {
                        int r1 = r + dirR[j];
                        int c1 = c + dirC[j];

                        // 영역 바깥일 경우
                        if (r1 >= 5 || r1 < 0
                          || c1 >= 5 || c1 < 0) continue;


                        if (room[r1, c1] == 'P')
                        {
                            // 바로 옆에 앉은 경우
                            if (j < 4)
                            {
                                isFail = 0;
                                break;
                            }
                            // 대각선에 앉은 경우
                            else if (Math.Abs(dirR[j]) == Math.Abs(dirC[j]))
                            {
                                // 가는 길 양쪽이 파티션이 아닌 경우
                                if (room[r1, c] != 'X' || room[r, c1] != 'X')
                                {
                                    isFail = 0;
                                    break;
                                }
                            }
                            // 한 자리 띄우고 앉은 경우
                            else
                            {
                                int center1 = r + dirR[j] / 2;
                                int center2 = c + dirC[j] / 2;

                                if (room[center1, center2] != 'X')
                                {
                                    isFail = 0;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            // 클리어
            answer[roomNumber] = isFail;
            roomNumber++;
        }
        return answer;
    }
    
    char[,] ChangeData(int roomNum, string[,] places)
    {
        char[,] room = new char[5,5];
        // 5x5 행렬로 변환
        for(int i = 0; i < 5; i++)
        {
            int count = 0;
            while(count < 5)
            {
                room[i, count] = places[roomNum, i][count];

                count++;
            }
        }
        return room;
    }
}