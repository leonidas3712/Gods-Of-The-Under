using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityFinalSpeed, gravityAcceleration;
    public static bool grounded, gravityActive;
    //bool onJavlin;
    Rigidbody2D rig;
    public static Gravity playerGravity;
    bool isTouching = false;
    Vector2 hitDir;

    void Awake()
    {
        rig = GetComponentInParent<Rigidbody2D>();
        gravityAcceleration = rig.gravityScale;
        playerGravity = this;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        grounded = false;

        hitDir = new Vector2(Mathf.Round(coll.GetContact(0).normal.x * 10) / 10, Mathf.Round(coll.GetContact(0).normal.y * 10) / 10);
        if (hitDir == Vector2.up)
        {
            grounded = true;
        }
        if (grounded == false)
        {
            if (coll.collider.tag == "javlin")
            {
                //anim.SetBool("grounded", true);
                grounded = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        grounded = false;
    }
    void Update()
    {
        if (rig.gravityScale != 0)
            if (rig.velocity.y < gravityFinalSpeed) rig.velocity = new Vector2(rig.velocity.x, gravityFinalSpeed);
    }
    public void ToggleGravity(bool active = true)
    {
        if (active)
        {
            rig.gravityScale = gravityAcceleration;
            gravityActive = true;
        }

        else
        {
            rig.gravityScale = 0;
            gravityActive = false;
        }

    }

}
