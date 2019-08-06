using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrag : MonoBehaviour
{
    public float dragStrngth, maxVelocity;
    Rigidbody2D rig;
    public static bool dragActive = true;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
                rig.velocity += Vector2.left * dragStrngth;
        }
        if (rig.velocity.x < 0)
        {
            if (rig.velocity.x < -maxVelocity)
                rig.velocity += Vector2.right * dragStrngth;
        }
    }
    public void SetDragPofile(float drag, float maxVel)
    {
        this.dragStrngth = drag;
        maxVelocity = maxVel;
    }

}
