public class Solution
{
    public int LeastInterval(char[] tasks, int n) 
    {
        var freqDict = new Dictionary<char, int>();
        var prioQueue = new PriorityQueue<char, int>();
        var cooldownQueue = new Queue<char>();
        var cycleCounter = 0;

        foreach (var task in tasks)
            freqDict[task] = freqDict.GetValueOrDefault(task) + 1;

        foreach (var item in freqDict)
            prioQueue.Enqueue(item.Key, -item.Value);

        while (prioQueue.Count != 0 || cooldownQueue.Count != 0)
        {
            if (freqDict.Count == 0) 
                return cycleCounter;
                
            cycleCounter++;

            if (cooldownQueue.Count == n + 1)
            {
                var element = cooldownQueue.Dequeue();
                if (element != '#')
                    prioQueue.Enqueue(element, -freqDict[element]);
            }

            if (prioQueue.Count != 0)
            {
                var candidate = prioQueue.Dequeue();

                if (--freqDict[candidate] == 0)
                {
                    freqDict.Remove(candidate);
                    cooldownQueue.Enqueue('#');
                }
                else cooldownQueue.Enqueue((candidate));
                
                continue;
            }

            cooldownQueue.Enqueue('#');
        }

        return cycleCounter;
    }
}
