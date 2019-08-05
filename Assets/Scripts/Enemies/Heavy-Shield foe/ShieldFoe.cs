using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFoe : Enemy
{
    Charge playerCharge;
    Animator animator;
    Vector2 PlayerDir;
    
    public bool attacked;

    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        playerCharge = Player.GetComponent<Charge>();
    }

    void Update()
    {
        PlayerDir = Player.transform.position - transform.position;
        if (!sighted && Vector2.Distance(transform.position, Player.transform.position) <= sightRange + 10)
        {
            if (SightPlayer(Vector2.right) || SightPlayer(Vector2.left)) sighted = true;
            else
                if (hp.Hp != hp.maxHp)
                sighted = true;
        }

        /*if (Attack.AbilityOn)
            Attack.DelayedAction();*/
        if (sighted && !hp.KnockBack_On)
        {
            if (Vector2.Distance(transform.position, Player.transform.position) < range)
            {
                if (playerCharge.AbilityOn)
                {
                    /*Attack.Cond = true;
                    Attack.DelayedAction();*/
                    if (!animator.GetBool("shieldUp") && !animator.GetBool("attack")) animator.SetBool("shieldUp", true);
                }
                else if (!animator.GetBool("attack") && !animator.GetBool("shieldUp")&& Vector2.Distance(transform.position, Player.transform.position) < range-2)
                {
                    animator.SetBool("attack", true);
                    rig.velocity = Vector2.zero;
                    attacked = false;
                }

            }
            else
            {
                if (animator.GetBool("shieldUp")) animator.SetBool("shieldUp", false);
                if (animator.GetBool("attack")) animator.SetBool("attack", false);
                Move(PlayerDir);
                attacked = false;
            }
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("shieldUp")) rig.velocity = Vector2.zero;
            else
            Flip(-PlayerDir.x);
        }
    }
    public void hitBoxCall(Collider2D collider)
    {
        if (collider.tag == "Player" && !attacked)
        {
            collider.GetComponent<PlayerHp>().TakeDamage(2, -PlayerDir);
            attacked = true;
        }
        if (collider.tag == "hitBox" && !attacked)
        {
            attacked = true;
        }
    }
   /* public override void OnCollisionEnter2D(Collision2D coll)
    {
        base.OnCollisionEnter2D(coll);
        if(coll.collider.tag=="Player") coll.collider.GetComponent<PlayerHp>().TakeDamage(1, -PlayerDir);
    }*/
}
