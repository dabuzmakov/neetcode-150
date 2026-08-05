public class Twitter
{
    private readonly Dictionary<int, List<(int, int)>> _tweetMap = new();
    private readonly Dictionary<int, HashSet<int>> _followMap = new();
    private int _tweetCounter = 0;
    
    public Twitter() { }
    
    private void PushLastTweet(int userId, PriorityQueue<(int, int, int), int> heap)
    {
        if (!_tweetMap.TryGetValue(userId, out var tweets) || tweets.Count == 0)
            return;

        heap.Enqueue(
            (tweets[^1].Item1, userId, tweets.Count - 1),
            -tweets[^1].Item2);
    }

    public List<int> GetNewsFeed(int userId)
    {
        var heap = new PriorityQueue<(int, int, int), int>();
        var result = new List<int>();

        PushLastTweet(userId, heap);
        if (_followMap.TryGetValue(userId, out var followies))
            foreach (var followee in followies)
                PushLastTweet(followee, heap);

        while (heap.Count != 0 && result.Count < 10)
        {
            var tweet = heap.Dequeue();
            var tweets = _tweetMap[tweet.Item2];
            result.Add(tweet.Item1);

            if (tweet.Item3 > 0)
                heap.Enqueue(
                    (tweets[tweet.Item3 - 1].Item1, tweet.Item2, tweet.Item3 - 1),
                    -tweets[tweet.Item3 - 1].Item2
                );
        }

        return result;
    }

    public void PostTweet(int userId, int tweetId)
    {
        _tweetMap.TryAdd(userId, []);
        _tweetMap[userId].Add((tweetId, _tweetCounter++));
    }
    
    public void Follow(int followerId, int followeeId)
    {
        if (followerId == followeeId)
            return;

        _followMap.TryAdd(followerId, []);
        _followMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId)
    {
        if (followerId == followeeId)
            return;
            
        _followMap[followerId].Remove(followeeId);
    }
}