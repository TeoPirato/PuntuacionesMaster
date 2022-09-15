using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    GameObject scoreParticipantPrefab;

    void OnEnable()
    {        
        var sortedParticipantsByScore = MatchManager.GetParticipantsSortedByScore();

        int i = 0;
        foreach (var pair in sortedParticipantsByScore)
        {
            ScoreParticipant newScoreParticipant;
            if (i >= transform.childCount)
                newScoreParticipant = Instantiate(scoreParticipantPrefab, transform).GetComponent<ScoreParticipant>();
            else 
                newScoreParticipant = transform.GetChild(i).GetComponent<ScoreParticipant>();

            newScoreParticipant.UpdateValues(i + 1, pair.Key, pair.Value);
            i++;
        }
    }
}
