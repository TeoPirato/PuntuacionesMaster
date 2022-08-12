using System.Collections.Generic;

public static class MatchManager
{
    public static int matchNumber = 0;

    static Dictionary<string, int> participants = new Dictionary<string, int>();
    public static void AddParticipantToMatch(string participant, int matchNumber)
    {
        if (!participants.ContainsKey(participant)) participants[participant] = 0;
    }
}
