using System;
using System.Collections.Generic;

public class Solution {
    // 기존 값을 재가공 하여 정의한 구조체 내부에 담아준다.
    // 예약 시작 시간을 기준으로 정렬하여 준다.
    // 최소 시작 시간을 시작으로 최대 시작 시간까지 측정한다.
    // 현재 시간이 시작 시간과 같다면 +1
    // 현재 시간 - 10이 끝나는 시간과 같다면 -1 -> 실제로 방을 쓸 수 있는 건 10분 뒤이기 때문
    public struct Book : IComparable<Book>
    {
        public int start;
        public int end;
        public Book(int s, int e)
        {
            start = s;
            end = e;
        }
        
        public int CompareTo(Book other) 
        {
            if(start < other.start) return -1;
            else if(start > other.start) return 1;
            else return 0;
        }
    }
    
    public int solution(string[,] book_time) {
        int answer = 0;
        int max = 0;
        
        Book[] arr = new Book[book_time.GetUpperBound(0) + 1];
        
        for(int i = 0; i < book_time.GetUpperBound(0) + 1; i++)
        {
           arr[i] = new Book(int.Parse(book_time[i, 0].Replace(":", "")),
                                 int.Parse(book_time[i, 1].Replace(":", "")));
        }
        
        Array.Sort(arr);
        
        int time = arr[0].start;
        bool[] booked = new bool[arr.Length];
        while(time <= arr[arr.Length - 1].start)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(booked[i] == false && arr[i].start == time)
                {
                    booked[i] = true;
                    max++;
                    if (max > answer) answer = max;
                }
                else if(booked[i] == true && arr[i].end == PrevTime(time))
                {
                    booked[i] = false;
                    max--;
                }
            }

            time = NextTime(time);
        }
        
        
        return answer;
    }
    
    int NextTime(int time)
    {
        time += 1;
        if(time % 100 == 60) time += 40;
        return time;
    }
    
    int PrevTime(int time)
    {
        if(time % 100 < 10) time -= 40;
        time -= 10;
        return time;
    }
}