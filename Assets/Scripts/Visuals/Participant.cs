using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Participant : MonoBehaviour
{
    Match match;
    int winningScore;
    bool showWinButtonOnChangeName;

    public void SetVariables(Match match, int winningScore, bool showWinButtonOnChangeName)
    {
        this.match = match;
        this.winningScore = winningScore;
        this.showWinButtonOnChangeName = showWinButtonOnChangeName;        
    }

    [SerializeField] TextMeshProUGUI participantName;
    [SerializeField] Button addButton, winButton, removeButton;

    void Start()
    {
        participantName.text = "";

        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        winButton.transform.localScale = removeButton.transform.localScale = Vector3.zero;
        winButton.interactable = removeButton.interactable = false;
    }

    public void AddParticipantToMatch()
    {
        ParticipantWindow.Instance.AddedParticipant += ChangeParticipantName; 
        ParticipantWindow.Instance.OpenWindow();
    }

    public void RemoveParticipantToMatch()
    {
        match.RemovedParticipant();

        participantName.text = "";

        addButton.interactable = true;
        addButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        removeButton.interactable = false;
        removeButton.transform.LeanScale(Vector3.zero, .2f);

        HideWinButton();
    }

    void ChangeParticipantName(string name)
    {
        ParticipantWindow.Instance.AddedParticipant -= ChangeParticipantName;
        if (name == null) return;


        MatchManager.AddScoreToParticipant(0, name);
        participantName.text = name;
        match.AddedParticipant();
        if (showWinButtonOnChangeName) ShowWinButton();

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

    public string ParticipantName => participantName.text;

    public void Win()
    {
        MatchManager.AddScoreToParticipant(winningScore, ParticipantName);
        match.DestroyMatch();
    }

    public void LoseJenga()
    {
        match.LoseJenga(this);
    }
}
