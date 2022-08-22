using System;
using TMPro;
using UnityEngine;

public class ParticipantWindow : MonoBehaviour
{
    static ParticipantWindow instance = null;
    public static ParticipantWindow Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<ParticipantWindow>();
            return instance;
        }
    }

    CanvasGroup canvasGroup;

    [SerializeField] TMP_InputField participantNameEntry;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        transform.localScale = Vector3.zero;
    }

    public void OpenWindow()
    {
        canvasGroup.LeanAlpha(1, .4f);
        transform.LeanScale(Vector3.one, .4f).setEaseOutBounce();

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        participantNameEntry.text = "";
    }

    public void CloseWindow()
    {
        canvasGroup.LeanAlpha(0, .2f);
        transform.LeanScale(Vector3.zero, .2f);

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public event Action<string> AddedParticipantName;
    public void DoneAddingParticipant()
    {        
        MatchManager.AddParticipantToMatch(participantNameEntry.text, 0);
        AddedParticipantName?.Invoke(participantNameEntry.text);
    }
}
