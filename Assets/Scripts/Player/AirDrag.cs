using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrag : MonoBehaviour
{
    public float dragStrngth, maxVelocity;
    Rigidbody2D rig;
    public static bool dragActive = true;
    public static AirDrag PlayerDrag;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        PlayerDrag = this;
    }
    private void Update()
    {
        if (dragActive) Drag();
    }
    void Drag()
    {
        if (rig.velocity.x > 0)
        {
            if (rig.velocity.x > maxVelocity)
            {
                if (rig.velocity.x - dragStrngth < maxVelocity) rig.velocity = new Vector2(maxVelocity, rig.velocity.y);
                else rig.velocity += Vector2.left * dragStrngth;
            } 
        }
        if (rig.velocity.x < 0)
        {
            if (rig.velocity.x < -maxVelocity)
            {
                if(rig.velocity.x+dragStrngth>maxVelocity) rig.velocity = new Vector2(maxVelocity, rig.velocity.y);
                else rig.velocity += Vector2.right * dragStrngth;
            }  
        }
    }

    public void SetDragPofile(float drag, float maxVel)
    {
        this.dragStrngth = drag;
        maxVelocity = maxVel;
    }

}
