using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int answer = 0;
    
    // 순서를 바꾸지 않고 
    public int solution(int[] numbers, int target) {
        F(numbers, target, -1);
        
        return answer;
    }
    
    private void F(int[] numbers, int target, int index)
    {

        index++;

        if (numbers.Length == index)
        {
            int total = 0;
            foreach (int num in numbers)
                total += num;

            if (total == target) answer++;

            return;
        }

        F(numbers, target, index);
        numbers[index] *= -1;
        F(numbers, target, index);

        
    }
}