using UnityEngine;

public class ScreensController : MonoBehaviour
{
    [SerializeField] GameObject matchesScreen, leaderboardScreen;

    GameObject toLeaderboardImage, toMatchesImage;

    void Start()
    {
        toLeaderboardImage = transform.GetChild(0).gameObject;
        toMatchesImage = transform.GetChild(1).gameObject;

        SetScreen(true);
    }

    void SetScreen(bool inMatchScreen)
    {
        matchesScreen.SetActive(inMatchScreen);
        toLeaderboardImage.SetActive(inMatchScreen);

        leaderboardScreen.SetActive(!inMatchScreen);
        toMatchesImage.SetActive(!inMatchScreen);
    }

    public void ChangeScreen()
    {
        SetScreen(!matchesScreen.activeSelf);
    }
}
