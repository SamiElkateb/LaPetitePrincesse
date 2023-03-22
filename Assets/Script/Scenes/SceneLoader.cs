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

    public void LoadMuserum()
    {
        SceneManager.LoadScene(2);
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