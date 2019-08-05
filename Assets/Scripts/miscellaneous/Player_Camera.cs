using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{

    Transform pos;

    public float speed = 0.125f;
    public Vector3 offset,ZonePoint;
    Vector3 desiredPos;
    public bool inPointZone;

    void Start()
    {
        pos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (inPointZone)
        {
            desiredPos = ZonePoint + offset;
        }
        else
            desiredPos = pos.position + offset;


        desiredPos = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);
        transform.position = desiredPos;
    }
   
}
