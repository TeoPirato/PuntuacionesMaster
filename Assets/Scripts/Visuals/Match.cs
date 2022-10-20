using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Match : MonoBehaviour
{
    [Header("Settings for each game")]
    [SerializeField] bool canTie;
    [Tooltip("If true, it shows all win buttons only after all participants have been added")]
    [SerializeField] bool showAllWinButtons;
    [SerializeField] int maximumParticipants;
    [SerializeField] int winningScore;
    [SerializeField] int maximumWinners;

    [SerializeField] GameObject participantPrefab;
    [SerializeField] Button tieButton;

    readonly List<Participant> participants = new List<Participant>();
    RectTransform verticalLayoutGroup;

    void Start()
    {
        verticalLayoutGroup = (RectTransform)transform.parent;

        InstantiateParticipant();

        tieButton.transform.localScale = Vector3.zero;
        tieButton.interactable = false;
    }

    public void AddedParticipant()
    {
        if (participants.Count < maximumParticipants)
            InstantiateParticipant();
        else
        {
            if (canTie)
            {
                tieButton.interactable = true;
                tieButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();
            }
            if (showAllWinButtons) ShowWinButtons();
        }
    }

    void ShowWinButtons()
    {
        foreach (var p in participants)
            p.ShowWinButton();
    }
    void HideWinButtons()
    {
        foreach (var p in participants)
            p.HideWinButton();
    }

    void InstantiateParticipant()
    {
        var newParticipant = Instantiate(participantPrefab, transform).GetComponent<Participant>();
        newParticipant.transform.SetSiblingIndex(transform.childCount - 2);
        newParticipant.SetVariables(this, winningScore, !showAllWinButtons);
        participants.Add(newParticipant);
    }

    public void RemovedParticipant()
    {
        if (canTie)
        {
            tieButton.interactable = false;
            tieButton.transform.LeanScale(Vector3.zero, .2f);
        }
        if (showAllWinButtons) HideWinButtons();
    }

    public void Tie()
    {
        string[] participantNames = participants.Select(p => p.ParticipantName).ToArray();
        MatchManager.AddScoreToParticipant(1, participantNames);

        DestroyMatch();
    }

    public void LoseJenga(Participant loser)
    {
        participants.Remove(loser);
        EliminateNamelessParticipant();
        MatchManager.AddScoreToParticipant(1, participants.Select(p => p.ParticipantName).ToArray());
        DestroyMatch();

        void EliminateNamelessParticipant()
        {
            if (participants[participants.Count - 1].ParticipantName == "")
                participants.RemoveAt(participants.Count - 1);
        }
    }

    int winners = 0;
    public void DestroyMatch()
    {
        winners++;
        if(winners >= maximumWinners)
            transform.LeanScale(Vector3.zero, .2f).setOnComplete(() => Destroy(gameObject));
    }
}
