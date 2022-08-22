using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Participant : MonoBehaviour
{
    [SerializeField] GameObject participantPrefab;
    [SerializeField] TextMeshProUGUI participantName;
    [SerializeField] Button addButton, winButton, removeButton;

    void Start()
    {
        participantName.text = "";
        participantName.alpha = .5f;

        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        winButton.transform.localScale = Vector3.zero;
        removeButton.transform.localScale = Vector3.zero;
    }

    public void AddParticipantToMatch()
    {
        ParticipantWindow.Instance.AddedParticipantName += ChangeParticipantName;
        ParticipantWindow.Instance.OpenWindow();
    }

    public void RemoveParticipantToMatch()
    {
        transform.LeanScale(Vector3.zero, .2f).setOnComplete(() => Destroy(gameObject));
    }

    void ChangeParticipantName(string name)
    {
        participantName.text = name;
        LeanTween.value(.5f, 1, .2f).setOnUpdate(value => participantName.alpha = value).setEaseOutCirc();
        ParticipantWindow.Instance.AddedParticipantName -= ChangeParticipantName;
        Instantiate(participantPrefab, transform.parent);

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
}
