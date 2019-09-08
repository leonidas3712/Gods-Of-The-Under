using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static GameObject Player;
    protected Rigidbody2D rig;
    [SerializeField]
    public float range = 5, speed, sightRange;
    Collision2D contactedColl;
    public bool grounded, sighted;
    public HP hp;
    int layerMask;
    Vector2 hitDir;

    public virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rig = GetComponent<Rigidbody2D>();
        hp = GetComponent<HP>();
        layerMask = ~(LayerMask.GetMask("Enemies"));
    }

    public virtual void Move(Vector3 dir)
    {
        if (dir.x > 0)
            rig.velocity = new Vector2(speed, rig.velocity.y);
        else
        if (dir.x < 0)
            rig.velocity = new Vector2(-speed, rig.velocity.y);
        else rig.velocity = new Vector2(0, rig.velocity.y);
    }
    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        hitDir = new Vector2(Mathf.Round(coll.GetContact(0).normal.x * 10) / 10, Mathf.Round(coll.GetContact(0).normal.y * 10) / 10);
        if (hitDir == Vector2.up)
        {
            grounded = true;
            contactedColl = coll;
        }
    }
    public virtual void OnCollisionExit2D(Collision2D coll)
    {
        if (contactedColl != null)
            if (contactedColl.GetContact(0).normal == Vector2.up && contactedColl.collider == coll.collider)
            {
                grounded = false;
            }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if ((coll.GetContact(0).normal == Vector2.up) && grounded == false)
        {
            grounded = true;
        }
    }
    public bool SightPlayer(Vector3 dir)
    {
        //check if the player is in sight
        //might be the reason for the bug you are solving!!!!!!!!
        Vector3 pos = transform.position /*+ dir*/;
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        RaycastHit2D playerSight = Physics2D.Raycast(pos, dir, sightRange,layerMask);
        if (playerSight && (playerSight.collider.tag == "Player" || playerSight.collider.tag == "javlin"))
            return true;
        return false;
    }
    protected void Flip(float x)
    {
        if (x > 0)
        {
            if (transform.localScale.x < 0)
            {

                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (x < 0)
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
    }
}
