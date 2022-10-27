using UnityEngine;
using UnityEngine.SceneManagement;

public class LogInManager : MonoBehaviour
{
    [SerializeField]
    int ajedrezScene, trucoScene, jengaScene, UNOScene, yinScene;

    public void EnterAjedrez() => SceneManager.LoadScene(ajedrezScene);
    public void EnterTruco() => SceneManager.LoadScene(trucoScene);
    public void EnterJenga() => SceneManager.LoadScene(jengaScene);
    public void EnterUNO() => SceneManager.LoadScene(UNOScene);
    public void EnterYin() => SceneManager.LoadScene(yinScene);

    int deleteDataCount = 0;
    public void DeleteData()
    {
        deleteDataCount++;

        if (deleteDataCount >= 3)
        {
            deleteDataCount = 0;
            MatchManager.DeleteScores();
        }
    }

    public void ShareData() => new NativeShare().AddFile(MatchManager.configPath, ".txt").Share();
}
