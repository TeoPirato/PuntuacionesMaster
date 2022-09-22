using UnityEngine;
using UnityEngine.UI;

public class DoneButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject nuevo;

    Button doneButton;

    void Start()
    {
        doneButton = GetComponent<Button>();
        doneButton.interactable = false;
    }

    public void OnParticipantNameChanged(string participantName)
    {
        bool isValidName = participantName != "";
        doneButton.interactable = isValidName;

        nuevo.SetActive(!MatchManager.ParticipantExists(participantName));
    }
}
