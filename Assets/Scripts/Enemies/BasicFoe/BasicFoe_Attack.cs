using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFoe_Attack : FoeAbility
{
    [SerializeField]
    float dashSpeed = 20;
    Vector2 PlayerDir;
    bool attacked;
    GameObject hitBox;
    HP hp;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        hitBox = transform.GetChild(0).gameObject;
        hitBox.SetActive(false);
        hp = GetComponent<HP>();
    }

    public override void Action()
    {
        PlayerDir = HelpfulFuncs.Norm1(Enemy.Player.transform.position - transform.position);
        rig.velocity = PlayerDir * dashSpeed;
        hitBox.SetActive(true);
    }
    public override void Finish()
    {
        rig.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        attacked = false;
        hitBox.SetActive(false);
    }
    public override void WhileIsOn()
    {
        //if (!GetComponent<Enemy>().grounded)
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg *-1+90);
    }
    public void hitBoxCall(Collision2D coll)
    {
        if (AbilityOn)
        {
            if (coll.collider.tag == "Player" && !attacked)
            {
                coll.collider.GetComponent<PlayerHp>().TakeDamage(1, -PlayerDir);
                attacked = true;
                ForceEnding();
                hp.KnockBack(-PlayerDir);
            }
            if (coll.collider.tag == "hitBox" && !attacked)
            {
                attacked = true;
                ForceEnding();
                hp.KnockBack(-PlayerDir);
            }
        }
    }
}
