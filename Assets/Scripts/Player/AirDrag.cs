using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDrag : MonoBehaviour
{
    public float drag, maxVelocity;
    Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rig.velocity.x > 0)
        {
            if (rig.velocity.x > maxVelocity)
                rig.velocity += Vector2.left * drag;
        }
        if (rig.velocity.x < 0)
        {
            if (rig.velocity.x < -maxVelocity)
                rig.velocity += Vector2.right * drag;
        }
    }
    public void SetDragPofile(float drag, float maxVel)
    {
        this.drag = drag;
        maxVelocity = maxVel;
    }
}
