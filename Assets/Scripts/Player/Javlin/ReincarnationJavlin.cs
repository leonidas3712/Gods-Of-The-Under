﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReincarnationJavlin : MonoBehaviour
{
    Rigidbody2D rig;
    bool flying = true, returning, stuckInEnemy;
    Quaternion rot;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        gameObject.layer = 11;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //hited an enemy
        if (coll.collider.tag == "foe" && flying)
        {
            Reincarnate.playerReinc.Hit(transform.position);
            coll.gameObject.GetComponent<HP>().TakeDamage(1, Vector2.zero);
            PlayerHp.playerHp.HealHp(1);
        }
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if (flying && !stuckInEnemy)
        {
            rot = Quaternion.Euler(0, 0, Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg * -1);
            transform.rotation = rot;
        }

    }
}
