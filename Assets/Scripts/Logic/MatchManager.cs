using System.Collections.Generic;
using System.Linq;

public static class MatchManager
{
    static int matchNumber = 0;
    public static int NewMatchNumber => matchNumber++;

    static readonly Dictionary<string, int> participants = new Dictionary<string, int>() { ["oi"] = 0, ["Teo Pirato Guthmann very large text on purpose"] = 10000 };

    public static void InitializeParticipants()
    {

    }

    public static void AddScoreToParticipant(int score, params string[] participantNames)
    {
        foreach (string name in participantNames)
        {
            if (!participants.ContainsKey(name)) participants[name] = score;
            else participants[name] += score;
        }
    }

    public static Dictionary<string, int> GetParticipantsSortedByScore()
    {
        return participants.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}
