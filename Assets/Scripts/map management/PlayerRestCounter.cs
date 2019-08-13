using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestCounter : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerRestCount", -1) == -1) PlayerPrefs.SetInt("PlayerRestCount", 1);
    }
    public void IncreaseRestCount()
    {
        PlayerPrefs.SetInt("PlayerRestCount", PlayerPrefs.GetInt("PlayerRestCount", 0)+1 );
    }
}
