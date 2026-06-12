public class Solution
{
    public bool IsPalindrome(string s)
    {
        var alphnum = "abcdefghijklmnopqrstuvwxyz0123456789";
        var normalized = s.ToLower().Where(x => alphnum.Contains(x) && x != ' ').ToArray();

        var left = 0;
        var right = normalized.Length - 1;
        while (right - left > 0)
        {
            if (normalized[left] != normalized[right])
                return false;
            
            left++;
            right--;   
        }
        
        return true;
    }
}
