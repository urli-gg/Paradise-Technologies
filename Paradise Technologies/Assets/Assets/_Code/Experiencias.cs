using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class Experiencias : MonoBehaviour
{
    [Button]
    public void SceneCoca()
    {
        SceneManager.LoadScene("Metaverso CC");
    }

    [Button]
    public void SceneBBVA()
    {
        SceneManager.LoadScene("BBVA");
    }

    [Button]
    public void SceneColgate()
    {
        SceneManager.LoadScene("Colgate");
    }

    [Button]
    public void SceneShieldforce()
    {
        SceneManager.LoadScene("Shieldforce");
    }

    [Button]
    public void SceneYakult()
    {
        SceneManager.LoadScene("Yakult");
    }

    [Button]
    public void SceneMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SceneExit()
    {
        Application.Quit();
    }
}
