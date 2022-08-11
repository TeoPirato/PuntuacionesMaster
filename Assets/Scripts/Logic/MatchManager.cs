using System.Collections.Generic;

public static class MatchManager
{
    static Dictionary<string, int> participants = new Dictionary<string, int>();
    static Dictionary<int, List<string>> matches = new Dictionary<int, List<string>>(); // IDK if this is really necessary, it may not be
    public static void AddParticipantToMatch(string participant, int matchNumber)
    {
        if (!matches.ContainsKey(matchNumber)) matches[matchNumber] = new List<string>();
        if (!participants.ContainsKey(participant)) participants[participant] = 0;

        matches[matchNumber].Add(participant);
    }
}
