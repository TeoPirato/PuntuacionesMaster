using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Participant : MonoBehaviour
{
    [HideInInspector]
    public Match match;

    [SerializeField] TextMeshProUGUI participantName;
    [SerializeField] Button addButton, winButton, removeButton;

    void Start()
    {
        ParticipantName = "";

        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        winButton.transform.localScale = removeButton.transform.localScale = Vector3.zero;
        winButton.interactable = removeButton.interactable = false;
    }

    public void AddParticipantToMatch()
    {
        ParticipantWindow.Instance.AddedParticipant += ChangeParticipantName;        
        ParticipantWindow.Instance.AddedParticipant += match.AddedParticipant;
        ParticipantWindow.Instance.OpenWindow();
    }

    public void RemoveParticipantToMatch()
    {
        match.RemovedParticipant();

        ParticipantName = "";

        addButton.interactable = true;
        addButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        removeButton.interactable = false;
        removeButton.transform.LeanScale(Vector3.zero, .2f);
    }

    void ChangeParticipantName(string name)
    {
        ParticipantName = name;
        ParticipantWindow.Instance.AddedParticipant -= ChangeParticipantName;

        addButton.interactable = false;
        addButton.transform.LeanScale(Vector3.zero, .2f);

        removeButton.interactable = true;
        removeButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();
    }

    public void ShowWinButton()
    {
        winButton.interactable = true;
        winButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();
    }

    public void HideWinButton()
    {
        winButton.interactable = false;
        winButton.transform.LeanScale(Vector3.zero, .2f);
    }

    public string ParticipantName
    {
        get => participantName.text;
        private set => participantName.text = value;
    }

    public void Win()
    {
        MatchManager.AddScoreToParticipant(2, ParticipantName);
        transform.parent.LeanScale(Vector3.zero, .2f).setOnComplete(() => Destroy(transform.parent.gameObject));
    }
}
