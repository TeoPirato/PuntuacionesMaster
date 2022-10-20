using System.Text;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI participantName, score;

    [SerializeField]
    int nameLenghtCap;

    void OnEnable()
    {        
        var sortedParticipantsByScore = MatchManager.GetParticipantsSortedByScore();

        int i = 0;

        StringBuilder participantNameString = new StringBuilder();
        StringBuilder scoreString = new StringBuilder();
        foreach (var pair in sortedParticipantsByScore)
        {
            string color = i switch
            {
                0 => "#ffd700",
                1 => "#c0c0c0",
                2 => "#cd7f32",
                _ => "#ffffff",
            };

            string cappedName = (pair.Key.Length >= nameLenghtCap) ? $"{pair.Key.Remove(nameLenghtCap, pair.Key.Length - nameLenghtCap)}..." : pair.Key;
            participantNameString.AppendLine($"<color={color}>{cappedName}</color>");
            scoreString.AppendLine($"{pair.Value:00}");

            i++;
        }

        participantName.text = participantNameString.ToString();
        score.text = scoreString.ToString();
    }
}
