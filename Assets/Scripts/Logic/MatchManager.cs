using System.Collections.Generic;

public class MatchManager
{
    List<List<string>> matches = new List<List<string>>();
    public void AddMatch(string firstParticipant)
    {
        var newMatch = new List<string>();
        newMatch.Add(firstParticipant);
        matches.Add(newMatch);
    }
}
