using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadPlanet1()
    {
        SceneManager.LoadScene("TestPlanet1");
    }

    public void LoadMuserum()
    {
        SceneManager.LoadScene("Museum");
    }

    public void LoadRace()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadHideAndSeek()
    {
        SceneManager.LoadScene(4);
    }
}