using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invuln : Ability
{

    //Collider2D coll;
    Color color;
    float timerer = 0, intervalses = 0.2f;
    private void Start()
    {
        canInterrupt = false;
        isInterruptable = false;
        //coll = GetComponent<Collider2D>();
        color = GetComponent<SpriteRenderer>().color;
    }
    public override void Action()
    {
        Physics2D.IgnoreLayerCollision(8,9,true);
    }
    public override void Finish()
    {
        Physics2D.IgnoreLayerCollision(8, 9,false);
        GetComponent<SpriteRenderer>().color = color;
    }
    public override void WhileIsOn()
    {
        if (timerer < Time.time)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
            timerer = Time.time + intervalses;
        }
        else
            GetComponent<SpriteRenderer>().color = color;

    }
    public override void CheckInput()
    {
    }
}
