using UnityEngine;

public class Teleport: MonoBehaviour
{
   public void TeleportToPosition(Vector3 position, Vector3 rotation)
   {
      Transform parentTransform = gameObject.transform.parent;
      parentTransform.position = position;
      parentTransform.rotation = Quaternion.Euler(rotation);
   }
}