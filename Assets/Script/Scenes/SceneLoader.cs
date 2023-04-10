using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void LoadPlanet1()
    {
        SceneManager.LoadScene("TestPlanet1");
    }

    public void LoadMuseum()
    {
        SceneManager.LoadScene("Museum");
    }

    public void LoadRace()
    {
        SceneManager.LoadScene("Planet2");
    }

    public void LoadHideAndSeek()
    {
        SceneManager.LoadScene("Planet3");
    }
    
    public void LoadEndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}