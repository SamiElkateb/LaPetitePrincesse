using UnityEngine;

public class Teleport: MonoBehaviour
{
   public void TeleportToPosition(Vector3 position)
   {
      gameObject.transform.parent.position = position;
   }
}