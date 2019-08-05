using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPoints :MonoBehaviour{

    Player_Camera camera;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player_Camera>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "camPoint")
        {
            camera.inPointZone = true;
            camera.ZonePoint = coll.transform.position;
        }

    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "camPoint")
        {
            camera.inPointZone = false;
        }
    }
}
