using System.Collections.Generic;

public static class MatchManager
{
    static int matchNumber = 0;
    public static int NewMatchNumber => matchNumber++;

    static Dictionary<string, int> participants = new Dictionary<string, int>();

    public static void AddScoreToParticipant(int score, params string[] participantNames)
    {
        foreach (string name in participantNames)
        {
            if (!participants.ContainsKey(name)) participants[name] = score;
            else participants[name] += score;
        }
        UnityEngine.Debug.Log(ScoresText());
    }    

    public static string ScoresText()
    {
        string text = "";
        foreach (string name in participants.Keys)
            text += $"\n{name}: {participants[name]}";
        return text;
    }
}
