using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invuln : TimedAction
{

    //Collider2D coll;
    Color color;
    float timerer = 0, intervalses = 0.2f;
    private void Start()
    {
        //coll = GetComponent<Collider2D>();
        color = GetComponent<SpriteRenderer>().color;
    }
    public override void Action()
    {
        foreach (GameObject foe in GameObject.FindGameObjectsWithTag("foe"))
        {
            foreach (Collider2D coll in GetComponents<Collider2D>())
                Physics2D.IgnoreCollision(coll, foe.GetComponent<Collider2D>());
        }
    }
    public override void Finish()
    {
        foreach (GameObject foe in GameObject.FindGameObjectsWithTag("foe"))
        {
            foreach (Collider2D coll in GetComponents<Collider2D>())
                Physics2D.IgnoreCollision(coll, foe.GetComponent<Collider2D>(), false);
        }
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
}
