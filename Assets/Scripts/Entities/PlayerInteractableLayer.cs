using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteractableLayer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable iOther = other.GetComponent<IInteractable>();
        if (iOther != null) {
            iOther.OnInteract(WorldManager.inst);
        }
    }
}
