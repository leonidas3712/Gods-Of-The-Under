using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public static PlayerControls playerActions;

    private void Awake()
    {
        playerActions = new PlayerControls();
        playerActions.Enable();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }
}
