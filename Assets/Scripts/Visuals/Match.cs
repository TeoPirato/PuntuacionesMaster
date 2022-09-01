using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class Match : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI matchNumberText;
    [SerializeField] GameObject participantPrefab;
    [SerializeField] Button drawButton;

    List<Participant> participants = new List<Participant>();

    RectTransform verticalLayoutGroup;

    void Start()
    {
        verticalLayoutGroup = (RectTransform)transform.parent;

        matchNumberText.text = $"#{MatchManager.NewMatchNumber:00}";

        InstantiateParticipant();

        drawButton.transform.localScale = Vector3.zero;
        drawButton.interactable = false;
    }

    public void AddedParticipant(string name)
    {
        if (participants.Count < 2)
            InstantiateParticipant();
        else
        {
            drawButton.interactable = true;
            drawButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();
            foreach (var p in participants)
                p.ShowWinButton();
        }

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
        drawButton.interactable = false;
        drawButton.transform.LeanScale(Vector3.zero, .2f);
        foreach (var p in participants)
            p.HideWinButton();        
    }

    public void Draw()
    {
        MatchManager.AddScoreToParticipant(1, participants.Select(p => p.ParticipantName).ToArray());

        transform.LeanScale(Vector3.zero, .2f).setOnComplete(() => Destroy(gameObject));
    }
}
