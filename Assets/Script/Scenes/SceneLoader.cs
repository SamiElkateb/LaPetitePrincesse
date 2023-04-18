using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);

    }
    public void LoadPlanet1()
    {
        SceneManager.LoadScene("Planet1", LoadSceneMode.Single);
    }

    public void LoadMuseum()
    {
        SceneManager.LoadScene("Museum", LoadSceneMode.Single);
    }

    public void LoadRace()
    {
        SceneManager.LoadScene("Planet2", LoadSceneMode.Single);
    }

    public void LoadHideAndSeek()
    {
        SceneManager.LoadScene("Planet3", LoadSceneMode.Single);
    }
    
    public void LoadEndGame()
    {
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }
}
