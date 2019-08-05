﻿using System.Collections;
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
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
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
            coll.collider.GetComponent<HP>().TakeDamage(1, HelpfulFuncs.Norm1(coll.collider.transform.position - transform.position));
        }
        //just staff
        else
        if (coll.collider.tag != "Player" && flying)
        {
            flying = false;
            rig.bodyType = RigidbodyType2D.Static;
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
            coll.GetComponent<Javlin>().javlinOn = true;
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
            spinDgree += 20f;
            transform.rotation = Quaternion.Euler(0, 0, spinDgree);
            rig.velocity = Vector3.Normalize(player.transform.position - transform.position) * 40;
        }

    }
    public void popOut()
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
