using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // TODO : not used now
    public Animator cameraIntroAnimator;
    public Camera playerCarCamera;
    public Camera playerCamera;
    public UIManager uiManager;

    public PlayerController playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;
    
    private Interactable rocketLauncherInteractable;
    private PlayerMovement _playerMovement;
    private Interactable carPlayerInteractable;
    
    public DialogueManager dialogueManager;
    public Dialogue dialogueWin;
    public Dialogue dialogueLose;
    
    public LapManager lapManager;

    private void Awake()
    {
        FreezePlayers(true);
        uiManager.DeactivateText();
    }

    private void Start()
    {
        // Desactivate the possibility to interact with the rocket
        rocketLauncherInteractable = GameObject.Find("RocketLauncher").GetComponent<Interactable>();
        rocketLauncherInteractable.Desactivate();
        
        _playerMovement = FindObjectOfType<Player>().GetComponent<PlayerMovement>();
    }

    public void StartIntro()
    {
        // followPlayerCamera.enabled = false;
        // cameraIntroAnimator.enabled = true;
    }

    public void StartCountdown()
    {
        // To close the interaction Canva displayed because of the car
        var _interactionPromptUI = GameObject.Find("InteractiveCanva").GetComponent<InteractionPromptUI>();
        _interactionPromptUI.Close();
        
        lapManager.StartLapManager();
        _resetPositionCar();
        
        // Desactivate the mesh renderer of the player
        uiManager.ActivateText();
        _setPlayerRendering(false);
        _playerMovement.enabled = false;
        
        // Change the camera of the player
        playerCarCamera.enabled = true;
        playerCamera.enabled = false;
        
        // Remove Script Interactable on the Car
        playerControls.GetComponent<Interactable>().enabled = false;

        // Start the countdown
        StartCoroutine("Countdown");
    }

    public void StartRacing()
    {
        FreezePlayers(false);
        _resetPositionCar();
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
        foreach (var aicontrol in aiControls)
        {
            aicontrol.enabled = !freeze;
            aicontrol.GetComponent<CarMovements>().enabled = !freeze;
        }
        
        playerControls.enabled = !freeze;
        playerControls.GetComponent<CarMovements>().enabled = !freeze;
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
    
    private void _resetPositionCar()
    {
        playerControls.GetComponent<TPCar>().ResetInitialPosition();
        foreach (var ai in aiControls)
        {
            ai.GetComponent<TPCar>().ResetInitialPosition();
            ai.Initialization();
        }
    }

    private void EndRace()
    {
        // Freeze Player
        FreezePlayers(true);
        _resetPositionCar();
        
        uiManager.DeactivateText();
        
        // enable player
        _setPlayerRendering(true);
        _playerMovement.enabled = true;
        playerCarCamera.enabled = false;
        playerCamera.enabled = true;
    }
    
    public void EndRaceLose()
    {
        EndRace();
        dialogueManager.StartDialogue(dialogueLose);
    }

    public void EndRaceWin()
    {
        EndRace();
        rocketLauncherInteractable.Activate();
        dialogueManager.StartDialogue(dialogueWin);
    }
}