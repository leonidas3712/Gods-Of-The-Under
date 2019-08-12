using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        FlipPlayer();
    }
    void FlipPlayer()
    {
        if (Input.anyKeyDown)
        {
            if (rig.velocity.x > 0)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }

            else if (rig.velocity.x < 0)
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
        }
    }
}
