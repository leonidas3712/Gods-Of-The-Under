using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    GameObject interactable;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Interactable") interactable = coll.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }
    void Start()
    {
        PlayerInput.playerActions.Player.Interact.performed += ActivateInteract;
    }

    void ActivateInteract(InputAction.CallbackContext context)
    {
        if (interactable) interactable.GetComponent<Interactable>().ActivateInteraction();
    }

}
