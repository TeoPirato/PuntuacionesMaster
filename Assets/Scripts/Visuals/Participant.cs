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
        participantName.text = "";
        //participantName.alpha = .5f;

        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        winButton.transform.localScale = Vector3.zero;
        removeButton.transform.localScale = Vector3.zero;
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

        participantName.text = "";

        addButton.interactable = true;
        addButton.transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        removeButton.interactable = false;
        removeButton.transform.LeanScale(Vector3.zero, .2f);
    }

    void ChangeParticipantName(string name)
    {        
        participantName.text = name;
        //LeanTween.value(.5f, 1, .2f).setOnUpdate(value => participantName.alpha = value).setEaseOutCirc();
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
}
