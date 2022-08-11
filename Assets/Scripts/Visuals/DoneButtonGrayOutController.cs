using UnityEngine;
using UnityEngine.UI;

public class DoneButtonGrayOutController : MonoBehaviour
{
    Button doneButton;

    void Start()
    {
        doneButton = GetComponent<Button>();
        GrayOutHandler(false);
    }

    public void OnParticipantNameChanged(string participantName)
    {
        bool isValidName = participantName != "";
        GrayOutHandler(isValidName);
    }

    private void GrayOutHandler(bool isValidName)
    {
        doneButton.interactable = isValidName;
        doneButton.image.color = isValidName ? Color.green : Color.gray;
    }
}
