using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSingleton : MonoBehaviour
{
    public static InputSingleton inputSingleton;
    public static InputManager inputActions = new InputManager();
    private void Awake()
    {
        inputSingleton = this;
    }
}
