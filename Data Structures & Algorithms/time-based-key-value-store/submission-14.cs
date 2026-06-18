public class TimeMap
{
    private readonly Dictionary<string, List<(int Time, string Value)>> _timeMap;

    public TimeMap()
        => _timeMap = new Dictionary<string, List<(int, string)>>();
    
    public void Set(string key, string value, int timestamp)
    {
        _timeMap.TryAdd(key, new List<(int, string)>());
        _timeMap[key].Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp)
    {
        if (!_timeMap.TryGetValue(key, out var states))
            return "";

        var left = 0;
        var right = states.Count - 1;
        var result = -1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (states[middle].Time <= timestamp)
            {
                result = middle;
                left = middle + 1;
            }
            else right = middle - 1;
        }

        return result == -1 ? "" : states[result].Value; 
    }
}
