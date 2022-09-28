using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLittle : Enemy
{
    bool stopped;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hp.KnockBack_On)
        {
            if (SightPlayer(HelpfulFuncs.Norm1(Player.transform.position - transform.position)))
                rig.velocity = HelpfulFuncs.Norm1(Player.transform.position - transform.position) * speed;
            else rig.velocity = Vector2.zero;
        }


    }
    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player"&&coll.collider.name!= "long javlin") PlayerHp.playerHp.TakeDamage(1, -HelpfulFuncs.Norm1(Player.transform.position - transform.position));
    }
}
