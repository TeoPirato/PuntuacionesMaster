using System.Collections.Generic;
using System.Linq;

public static class MatchManager
{
    static int matchNumber = 0;
    public static int NewMatchNumber => matchNumber++;

    static readonly SortedList<string, int> participants = new SortedList<string, int>();
    static readonly SortedSet<string> names = new SortedSet<string>();

    public static void InitializeParticipants()
    {

    }

    public static void AddScoreToParticipant(int score, params string[] participantNames)
    {
        foreach (string name in participantNames)
        {
            if (!names.Contains(name))
            {
                names.Add(name);
                participants[name] = score;
            }
            else participants[name] += score;
        }
    }

    public static Dictionary<string, int> GetParticipantsSortedByScore()
    {
        return participants.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public static bool ParticipantExists(string participantName) => names.Contains(participantName);
}
