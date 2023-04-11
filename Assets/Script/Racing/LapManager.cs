using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps = 3;
    public UIManager ui;

    private List<PlayerRank> playerRanks;
    private PlayerRank mainPlayerRank;
    [FormerlySerializedAs("onPlayerFinished")] public UnityEvent onPlayerFinishedWin = new UnityEvent();
    public UnityEvent onPlayerFinishedLoose = new UnityEvent();
    public string PlayerCarTag = "PlayerCar";

    public void StartLapManager()
    {
        playerRanks = new List<PlayerRank>();
        Debug.Log("Start Received");
        // Get players in the scene
        foreach(CarIdentity carIdentity in FindObjectsOfType<CarIdentity>())
        {
            playerRanks.Add(new PlayerRank(carIdentity));
        }
        ListenCheckpoints(true);
        ui.UpdateLapText("Tour : "+ playerRanks[0].lapNumber + " / " + totalLaps);
        Debug.Log("Tour : "+ playerRanks[0].lapNumber + " / " + totalLaps);
        mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.CompareTag(PlayerCarTag));
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach(Checkpoint checkpoint in checkpoints) {
            if(subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(CarIdentity car, Checkpoint checkpoint)
    {
        PlayerRank player = playerRanks.Find((rank) => rank.identity == car);
        if (checkpoints.Contains(checkpoint) && player!=null)
        {
            // if player has already finished don't do anything
            if (player.hasFinished) return;

            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && player.lastCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && player.lastCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished) 
            { 
                player.lapNumber += 1;
                player.lastCheckpoint = 0;

                // if this was the final lap
                if (player.lapNumber > totalLaps)
                {
                    player.hasFinished = true;
                    // getting final rank, by finding number of finished players
                    player.rank = playerRanks.FindAll(player => player.hasFinished).Count;

                    // if first winner, display its name
                    if (player.rank == 1)
                    {
                        Debug.Log(player.identity.driverName + " a gagné");
                        ui.UpdateLapText(player.identity.driverName + " a gagné");
                    }
                    else if (player == mainPlayerRank) // display player rank if not winner
                    {
                        ui.UpdateLapText("\nVous avez fini à la " + mainPlayerRank.rank + " place");
                        onPlayerFinishedLoose.Invoke();
                    }

                    if (player == mainPlayerRank) onPlayerFinishedWin.Invoke();
                }
                else {
                    Debug.Log(player.identity.driverName + ": lap " + player.lapNumber);
                    if(car.gameObject.CompareTag(PlayerCarTag)) ui.UpdateLapText("Tour : " + player.lapNumber + " / " + totalLaps);
                }
            }
            // next checkpoint reached
            else if (checkpointNumber == player.lastCheckpoint + 1)
            {
                player.lastCheckpoint += 1;
            }
        }
    }
}
