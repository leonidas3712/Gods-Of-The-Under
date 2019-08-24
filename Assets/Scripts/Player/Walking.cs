using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float acceleration = 2, maxVelocity = 7, drag = 1;
    Rigidbody2D rig;
    public static Walking playerWalking;
    private void Awake()
    {
        Gravity.playerGravity.groundCall += new Gravity.GroundCall(setDrag);
        playerWalking = this;
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    public void Walk()
    {
        if (Input.GetKey("a"))
        {
            if (rig.velocity.x > -maxVelocity)
            {
                MoveHorizontaly(-acceleration);
            }
            //else if (rig.velocity.x != -maxVelocity) rig.velocity = new Vector2(-maxVelocity, rig.velocity.y);
        }
        else
        if (Input.GetKey("d"))
        {
            if (rig.velocity.x < maxVelocity)
            {
                MoveHorizontaly(acceleration);
            }
            //else if (rig.velocity.x != maxVelocity) rig.velocity = new Vector2(maxVelocity, rig.velocity.y);
        }

        if ((Input.GetKey("a") || Input.GetKey("d")) && Mathf.Abs(rig.velocity.x) <= maxVelocity)
        {
            AirDrag.PlayerDrag.SetDragPofile(drag, 0);
        }

        /* if (!Input.GetKey("a") && !Input.GetKey("d"))
         {
             if (/*Mathf.Abs(rig.velocity.x) <= maxVelocity + 0.5f || Gravity.grounded) rig.velocity = new Vector2(0, rig.velocity.y);
         }*/
    }
    void setDrag()
    {
        AirDrag.PlayerDrag.SetDragPofile(drag, 0);
    }
    void MoveHorizontaly(float acc)
    {
        float sign = acc / Mathf.Abs(acc);
        if (Mathf.Abs(rig.velocity.x) + Mathf.Abs(acc) > maxVelocity && rig.velocity.x * sign >= 0)
        {
            rig.velocity = new Vector2(maxVelocity * sign, rig.velocity.y);
        }
        else
        {
            if (rig.velocity.x * sign <= 0 && Mathf.Abs(rig.velocity.x) <= maxVelocity && Gravity.grounded)
                rig.velocity *= Vector2.up;
            rig.velocity = new Vector2(acc + rig.velocity.x, rig.velocity.y);
        }
    }
}
