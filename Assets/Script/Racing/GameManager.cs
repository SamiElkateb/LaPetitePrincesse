using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // TODO : not used now
    public Animator cameraIntroAnimator;
    public Camera playerCarCamera;
    public Camera playerCamera;

    public PlayerController playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    
    private void Awake()
    {
        StartIntro();
    }

    public void StartIntro()
    {
        // followPlayerCamera.enabled = false;
        // cameraIntroAnimator.enabled = true;
        FreezePlayers(true);
    }

    public void StartCountdown()
    {
        // Desactivate the mesh renderer of the player
        _setPlayerRendering(false);
        FindObjectOfType<Player>().GetComponent<PlayerMovement>().enabled = false;
        
        // Change the camera of the player
        playerCarCamera.enabled = true;
        playerCamera.enabled = false;
        StartCoroutine("Countdown");
    }

    public void StartRacing()
    {
        FreezePlayers(false);
    }

    private IEnumerator Countdown()
    {
        Debug.Log("3");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(1);
        yield return new WaitForSeconds(1);

        Debug.Log("2");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(2);
        yield return new WaitForSeconds(1);

        Debug.Log("1");
        audioSource.PlayOneShot(lowBeep);
        tricolorLights.SetProgress(3);
        yield return new WaitForSeconds(1);

        Debug.Log("GO");
        tricolorLights.SetProgress(4);
        audioSource.PlayOneShot(highBeep);

        StartRacing();

        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }

    private void FreezePlayers(bool freeze)
    {
        foreach (var aicontrol in aiControls) aicontrol.enabled = !freeze;
        playerControls.enabled = !freeze;
    }

    private void _setPlayerRendering(bool boolean)
    {
        Player player = FindObjectOfType<Player>();
        foreach (var texture in player.GetComponentsInChildren<MeshRenderer>())
        {
            texture.enabled = boolean;
        }

        foreach (var texture in player.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            texture.enabled = boolean;
        }
    }
}