using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFoe : Enemy
{
    public FoeAbility Attack;
    public override void Start()
    {
        base.Start();
        Attack = GetComponent<FoeAbility>();
    }
    private void Update()
    {
        if (!sighted && Vector2.Distance(transform.position, Player.transform.position) <= sightRange+10)
        {
            if (SightPlayer(Vector2.right) || SightPlayer(Vector2.left)) sighted = true;
            else
                if (GetComponentInChildren<Thrown_Javlin>())
                sighted = true;
        }


        if (Attack.AbilityOn)
            Attack.DelayedAction();
        else
        if (grounded)
        {
            if (sighted && Vector2.Distance(transform.position, Player.transform.position) <= sightRange + 10)
            {
                if (Player && Vector2.Distance(transform.position, Player.transform.position) >= range)
                {
                    if (!GetComponent<HP>().KnockBack_On)
                        Move(Player.transform.position - transform.position);
                }
                else
                {
                    //rig.velocity = new Vector2(0, rig.velocity.y);
                    if (!Attack.AbilityOn)
                    {
                        Attack.Cond = true;
                        Attack.DelayedAction();
                    }
                }
            }
            else
                rig.velocity = new Vector2(0, rig.velocity.y);
        }

    }

}
