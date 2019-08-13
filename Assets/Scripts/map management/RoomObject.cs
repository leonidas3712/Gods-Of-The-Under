using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomObject : MonoBehaviour
{
    public string objectName;
    public virtual void Awake()
    {
        GameObject.FindObjectOfType<Room>().onResetRoom += new Room.OnResetRoom(OnRoomReset);
        objectName =SceneManager.GetActiveScene().name+"_"+gameObject.name;
    }
    public virtual void OnRoomReset()
    {

    }
}
