using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestShrine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<PlayerRestCounter>().IncreaseRestCount();
        }
    }
}
