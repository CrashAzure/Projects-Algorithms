public class Solution {
    
    public int RomanToInt(string s) 
    {
        Dictionary<char, int> romans = new Dictionary<char, int>{{'M', 1000},{'D', 500},{'C', 100},{'L', 50},{'X', 10},{'V', 5},{'I', 1}};
        int answer = 0;
        
        for(int i = 0; i < s.Length - 1; i++)
        {
            if(romans[s[i]] < romans[s[i + 1]]) answer -= romans[s[i]];
            else answer += romans[s[i]];
        }
        answer += romans[s[s.Length - 1]];
        return answer;
    }
    
}