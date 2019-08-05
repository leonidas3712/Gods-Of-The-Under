﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{

    public int maxHp = 5, Hp;
    public bool KnockBack_On;
    Rigidbody2D rig;
    [SerializeField]
    float KnockBack_Length = 0.15f, KnockBack_Strength = 10, timer = 0, basicMovmentSpeed = 5;
    private void Start()
    {
        Hp = maxHp;
        rig = GetComponent<Rigidbody2D>();
        if (GetComponent<Enemy>())
            basicMovmentSpeed = GetComponent<Enemy>().speed;
    }
    public void TakeDamage(int damage, Vector3 dir)
    {
        Hp -= damage;
        KnockBack(dir);
        if (Hp <= 0)
        {
            if (GetComponentInChildren<Thrown_Javlin>())
                GetComponentInChildren<Thrown_Javlin>().popOut();
            Destroy(gameObject);
        }
    }
    public void KnockBack(Vector3 dir)
    {
        KnockBack_On = true;
        rig.gravityScale = 0;
        timer = Time.time + KnockBack_Length;
        rig.velocity = dir * KnockBack_Strength;
    }
    private void FixedUpdate()
    {
        if (timer <= Time.time && KnockBack_On)
        {
            //starts slowing down
            rig.gravityScale = Character_Controller.GravityScale;
            if (rig.velocity.x > 0)
                rig.velocity = new Vector2(rig.velocity.x - 0.8f, rig.velocity.y);
            else
                rig.velocity = new Vector2(rig.velocity.x + 0.8f, rig.velocity.y);
            //stop the knockback when veloctiy hits below walking speed
            if (Mathf.Abs(rig.velocity.x) <= basicMovmentSpeed)
            {
                KnockBack_On = false;
            }
        }
    }
}
