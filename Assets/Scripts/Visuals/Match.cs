using UnityEngine;
using TMPro;

public class Match : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI matchNumberText;

    int matchNumber;

    void Start()
    {
        matchNumber = MatchManager.matchNumber++;
        matchNumberText.text = $"#{matchNumber}";
    }

    public void AddParticipantToMatch()
    {
        // Open participant window
    }
}
