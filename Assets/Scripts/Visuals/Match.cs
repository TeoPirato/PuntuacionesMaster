using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Match : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI matchNumberText;
    [SerializeField] GameObject participantPrefab;

    int matchNumber;

    List<Participant> participants = new List<Participant>();

    RectTransform verticalLayoutGroup;

    void Start()
    {
        verticalLayoutGroup = (RectTransform)transform.parent;

        matchNumber = MatchManager.matchNumber++;
        matchNumberText.text = $"#{matchNumber:00}";

        InstantiateParticipant();
    }

    public void AddedParticipant(string name)
    {
        if (participants.Count < 2)
            InstantiateParticipant();
        else foreach (var p in participants)
            p.ShowWinButton();

        ParticipantWindow.Instance.AddedParticipant -= AddedParticipant;
    }

    void InstantiateParticipant()
    {
        var newParticipant = Instantiate(participantPrefab, transform).GetComponent<Participant>();
        newParticipant.match = this;
        participants.Add(newParticipant);

        LayoutRebuilder.ForceRebuildLayoutImmediate(verticalLayoutGroup);
    }

    public void RemovedParticipant()
    {
        foreach (var p in participants)
            p.HideWinButton();        
    }
}
