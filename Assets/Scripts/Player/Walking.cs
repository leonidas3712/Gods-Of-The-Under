using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float acceleration = 2, maxVelocity = 7;
    Rigidbody2D rig;
    AirDrag airDrag;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        airDrag = GetComponent<AirDrag>();
    }

    public void Walk()
    {
        if (rig.velocity.x > -maxVelocity)
        {
            if (Input.GetKey("a"))
            {
                MoveHorizontaly(-acceleration);
            }
        }
        if (rig.velocity.x < maxVelocity)
            if (Input.GetKey("d"))
            {
                MoveHorizontaly(acceleration);
            }

        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            //anim.SetBool("isRunning", false);
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
    }

    void MoveHorizontaly(float acc)
    {
        rig.velocity = new Vector2(acc + rig.velocity.x, rig.velocity.y);
        //anim.SetBool("isRunning", true);
    }
}
