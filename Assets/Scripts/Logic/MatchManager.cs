using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class MatchManager
{
    static int matchNumber = 0;
    public static int NewMatchNumber => matchNumber++;

    static readonly SortedList<string, int> participants = new SortedList<string, int>();
    static readonly SortedSet<string> names = new SortedSet<string>();

    readonly static string configPath = Application.persistentDataPath + "/data.txt";

    public static void InitializeParticipants()
    {
        if(!File.Exists(configPath))
        {
            SaveScores();
            return;
        }

        string[] lines = File.ReadAllLines(configPath);

        participants.Clear();
        names.Clear();
        foreach (string line in lines)
        {
            string[] pair = line.Remove(line.Length - 1, 1).Remove(0, 1).Split(',');
            names.Add(pair[0]);
            participants.Add(pair[0], int.Parse(pair[1]));
        }
    }

    public static void SaveScores()
    {
        File.WriteAllLines(configPath, participants.Select(v => $"{v}"));
    }

    public static void DeleteScores()
    {
        participants.Clear();
        names.Clear();
        File.WriteAllText(configPath, "");
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
