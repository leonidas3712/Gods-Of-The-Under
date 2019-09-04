using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyMapEnemy : RoomObject
{
    public override void OnRoomReset()
    {
        PlayerPrefs.SetInt(objectName + "_ShouldSpawn", 1);
    }
    void LateUpdate()
    {
        int shouldRespawn = PlayerPrefs.GetInt(objectName + "_ShouldSpawn", -1);
        if (shouldRespawn == 0) gameObject.SetActive(false);
        else if (shouldRespawn == -1) PlayerPrefs.SetInt(objectName + "_ShouldSpawn", 1);
    }
}
