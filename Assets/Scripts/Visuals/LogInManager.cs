using UnityEngine;
using UnityEngine.SceneManagement;

public class LogInManager : MonoBehaviour
{
    [SerializeField]
    int ajedrezScene, trucoScene, jengaScene, UNOScene;

    public void EnterAjedrez() => SceneManager.LoadScene(ajedrezScene);
    public void EnterTruco() => SceneManager.LoadScene(trucoScene);
    public void EnterJenga() => SceneManager.LoadScene(jengaScene);
    public void EnterUNO() => SceneManager.LoadScene(UNOScene);

    public void DeleteData() => MatchManager.DeleteScores();
}
