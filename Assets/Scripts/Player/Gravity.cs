using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityFinalSpeed, gravityAcceleration;
    public static bool grounded, gravityActive;
    //bool onJavlin;
    Rigidbody2D rig;
    float colliderHight, colliderWidth;
    RaycastHit2D[] groundCheckHits;
    int layermask;
    public static Gravity playerGravity;
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        layermask = ~(LayerMask.GetMask("Player", "Ignore Raycast"));
        gravityAcceleration = rig.gravityScale;
        playerGravity = this;
    }
    private void Start()
    {
        colliderHight = GetComponent<Collider2D>().bounds.size.y;
        colliderWidth = GetComponent<Collider2D>().bounds.size.x;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (grounded == false)
        {
            if (coll.collider.tag == "javlin")
            {
                //anim.SetBool("grounded", true);
                grounded = true;
            }
        }
    }
    public void GroundCheck()
    {
        grounded = false;
        groundCheckHits = new RaycastHit2D[3];
        groundCheckHits[0] = Physics2D.Raycast(transform.position, Vector2.down, colliderHight / 2 + 0.07f, layermask);
        groundCheckHits[1] = Physics2D.Raycast(transform.position + (Vector3)Vector2.right * colliderWidth / 2, Vector2.down, colliderHight / 2 + 0.07f, layermask);
        groundCheckHits[2] = Physics2D.Raycast(transform.position + (Vector3)Vector2.left * colliderWidth / 2, Vector2.down, colliderHight / 2 + 0.07f, layermask);
        foreach (RaycastHit2D hit in groundCheckHits)
        {
            if (hit.collider)
            {
                Vector2 hitDir = new Vector2(Mathf.Round(hit.normal.x * 10) / 10, Mathf.Round(hit.normal.y * 10) / 10);
                if (hitDir==Vector2.up|| hit.collider.tag == "javlin")
                {
                    grounded = true;
                    break;
                }
            }
        }
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
