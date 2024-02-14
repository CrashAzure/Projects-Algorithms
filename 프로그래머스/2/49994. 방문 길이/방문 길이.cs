using System;

public class Solution {
    public int solution(string dirs) {
        int answer = 0;
        bool[,] u = new bool[11,11];
        bool[,] d = new bool[11,11];
        bool[,] l = new bool[11,11];
        bool[,] r = new bool[11,11];
        int xPos = 5;
        int yPos = 5;
        
        
        char[] c = dirs.ToCharArray();
        
        for(int i = 0; i < c.Length; i++)
        {
            switch (c[i])
            {
                case 'U':
                    if(yPos < 10) 
                    {
                        yPos++;
                    
                        if(u[xPos,yPos] == false)
                        {
                            u[xPos,yPos] = true;
                            d[xPos,yPos - 1] = true;
                            answer++;
                        }
                    }
                    break;
                case 'D':
                    if(yPos >= 1) 
                    {
                        yPos--;
                        if(d[xPos,yPos] == false)
                        {
                            u[xPos,yPos + 1] = true;
                            d[xPos,yPos] = true;
                            answer++;
                        }
                    }
                    
                    break;
                case 'L':
                    if(xPos >= 1)
                    {
                         xPos--;
                        if(l[xPos,yPos] == false)
                        {
                            l[xPos,yPos] = true;
                            r[xPos + 1,yPos] = true;
                            answer++;
                        }
                    }
                    break;
                case 'R':
                    if(xPos < 10) 
                    {
                        xPos++;
                        if(r[xPos,yPos] == false)
                        {
                            l[xPos - 1,yPos] = true;
                            r[xPos,yPos] = true;
                            answer++;
                        }
                    }
                    break;
            }
        }
        
        
        return answer;
    }
}