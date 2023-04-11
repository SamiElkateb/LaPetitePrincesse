using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // needed to use UnityEvent

public class Checkpoint : MonoBehaviour
{
   public UnityEvent<CarIdentity, Checkpoint> onCheckpointEnter;
   void OnTriggerEnter(Collider collider)
   {
       // if entering object is tagged as the Player
       CarIdentity res = collider.gameObject.GetComponent<CarIdentity>();
       if (res != null)
       {
           Debug.Log(collider.gameObject.GetComponent<CarIdentity>().driverName + " entered checkpoint " + gameObject.name);
           // fire an event giving the entering gameObject and this checkpoint
           onCheckpointEnter.Invoke(res, this);
       }
   }
}
