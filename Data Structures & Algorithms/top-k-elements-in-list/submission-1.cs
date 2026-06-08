public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var freqDict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (freqDict.TryGetValue(num, out var count))
                freqDict[num] = count + 1;
            else freqDict[num] = 1;
        }

        return freqDict.ToArray().OrderBy(x => -x.Value).Select(x => x.Key).Take(k).ToArray();
    }
}
