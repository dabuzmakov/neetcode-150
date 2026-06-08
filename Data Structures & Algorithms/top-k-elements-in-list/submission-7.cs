public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freqDict = new Dictionary<int, int>();

        foreach (var num in nums)
            freqDict[num] = freqDict.GetValueOrDefault(num, 0) + 1;

        var buckets = new List<int>[nums.Length + 1];

        foreach (var pair in freqDict)
        {
            var count = pair.Value;
            if (buckets[count] == null)
                buckets[count] = new List<int>();

            buckets[count].Add(pair.Key);
        }
            
        var result = new List<int>();
        for (var i = buckets.Length - 1; i > 0 && result.Count != k; i--)
        {
            if (buckets[i] == null)
                continue;
                
            foreach (var num in buckets[i])
            {
                if (result.Count == k)
                    break;
                
                result.Add(num);
            }
        }

        return result.ToArray();
    }
}
