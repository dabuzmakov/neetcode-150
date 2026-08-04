public class Solution
{
    public int LeastInterval(char[] tasks, int n) 
    {
        var freqDict = new Dictionary<char, int>();
        var prioQueue = new PriorityQueue<char, int>();
        var cooldownQueue = new Queue<(char, int)>();
        var cycleCounter = 0;

        foreach (var task in tasks)
            freqDict[task] = freqDict.GetValueOrDefault(task) + 1;

        foreach (var item in freqDict)
            prioQueue.Enqueue(item.Key, -item.Value);

        while (prioQueue.Count != 0 || cooldownQueue.Count != 0)
        {
            cycleCounter++;

            if (cooldownQueue.Count != 0 && cooldownQueue.Peek().Item2 == cycleCounter)
            {
                var element = cooldownQueue.Dequeue();
                prioQueue.Enqueue(element.Item1, -freqDict[element.Item1]);
            }

            if (prioQueue.Count != 0)
            {
                var candidate = prioQueue.Dequeue();

                if (--freqDict[candidate] != 0)
                    cooldownQueue.Enqueue((candidate, cycleCounter + n + 1));
            }
        }

        return cycleCounter;
    }
}
