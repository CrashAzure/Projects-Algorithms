using System;

public class Solution {
    public int[,] solution(int[,] arr1, int[,] arr2) {
        int[,] answer = new int[arr1.GetLength(0),arr2.GetLength(1)];
        // 행
        for(int i = 0; i < arr1.GetLength(0); i++ )
        {
            for(int j = 0; j < arr2.GetLength(1); j++)
            {
                for(int k = 0; k < arr1.GetLength(1); k ++)
                {
                    answer[i, j] += arr1[i, k] * arr2[k, j];
                }
            }
        }
        
        
        
        return answer;
    }
}