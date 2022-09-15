using UnityEngine;
using TMPro;

public class ScoreParticipant : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI position, participantName, score;

    public void UpdateValues(int position, string participantName, int score)
    {
        this.position.text = $"#{position:00}";
        this.participantName.text = participantName;
        this.score.text = $"{score:00}";
    }
}
