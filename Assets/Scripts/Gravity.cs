using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityFinalSpeed, gravityAcceleration;
    public static bool gravityActive;
    Rigidbody2D rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        /*if (gravityActive)
            if (rig.velocity.y > gravityFinalSpeed) rig.velocity += Vector2.down * gravityAcceleration;*/
        if (rig.gravityScale != 0)
            if (rig.velocity.y < gravityFinalSpeed) rig.velocity = new Vector2(rig.velocity.x, gravityFinalSpeed);
    }
}
