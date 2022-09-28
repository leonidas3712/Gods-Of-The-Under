using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Room : MonoBehaviour
{
    public delegate void OnResetRoom();
    public event OnResetRoom onResetRoom;

    private void Start()
    {
        int playerRestCount = PlayerPrefs.GetInt("PlayerRestCount");
        if(playerRestCount != PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "RestCount"))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "RestCount", playerRestCount);
            onResetRoom();
        }
    }
}
