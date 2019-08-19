using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrown_Javlin : MonoBehaviour
{
    Rigidbody2D rig;
    public bool flying = true, returning, stuckInEnemy;
    GameObject player;
    float spinDgree = 0;
    Quaternion rot;
    Vector3 stickPosition;
    Charge charge;
    Throw throwAbility;
    Throw_Bow bow;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        charge =player.GetComponent<Charge>();
        throwAbility = player.GetComponent<Throw>();
        bow = player.GetComponent<Throw_Bow>();
        gameObject.layer = 11;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //hited an enemy
        if (coll.collider.tag == "foe" && flying)
        {

            stuckInEnemy = true;
            flying = false;
            rig.isKinematic = true;
            rig.velocity = Vector2.zero;
            
            transform.parent = coll.collider.transform;
            foreach (Collider2D Mycoll in GetComponents<Collider2D>())
            {
                Mycoll.isTrigger = true;
            }
            rig.freezeRotation = true;
            GetComponentInParent<HP>().TakeDamage(player.GetComponent<Throw>().damage, HelpfulFuncs.Norm1(coll.collider.transform.position - transform.position)*0);
            charge.ResetTimesDone();
            throwAbility.ResetTimesDone();
            bow.ResetTimesDone();
            gameObject.layer = 0;
        }
        //just staff
        else
        if (coll.collider.tag != "Player" && flying)
        {
            flying = false;
            rig.bodyType = RigidbodyType2D.Static;
            gameObject.layer = 0;
        }
        //enemy knocks out the lance
        else
        if (coll.collider.tag == "foe" && !flying && !stuckInEnemy)
        {
            rig.bodyType = RigidbodyType2D.Dynamic;
            rig.gravityScale = 6;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && returning)
        {
            Character_Controller.javlinOn = true;
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (flying && !stuckInEnemy)
        {
            rot = Quaternion.Euler(0, 0, Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg * -1);
            transform.rotation = rot;
        }
        else
            if (returning)
        {
            spinDgree += 15f;
            transform.rotation = Quaternion.Euler(0, 0, spinDgree);
            rig.velocity = Vector3.Normalize(player.transform.position - transform.position) * CallBack.call.returnSpeed;
        }

    }
    public void PopOut()
    {
        transform.parent = null;
        rig.bodyType = RigidbodyType2D.Dynamic;
        rig.gravityScale = 6;
        foreach (Collider2D coll in GetComponents<Collider2D>())
        {
            coll.isTrigger = false;
        }
        stuckInEnemy = false;
        foreach (Collider2D coll in player.GetComponents<Collider2D>())
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), coll);
    }
}
