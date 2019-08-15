using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Ability
{
    Vector3 boostDirection;
    Rigidbody2D rig;
    public float boostStrength;
    public void StartBoost(Vector3 dir)
    {
        boostDirection = dir;
        TriggerAbility();
    }
    public override void CheckInput()
    {
       
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    public override void Action()
    {
        Gravity.playerGravity.ToggleGravity(false);
        rig.velocity = boostDirection*boostStrength;
    }
    public override void Finish()
    {
        Gravity.playerGravity.ToggleGravity();
    }
    public override void WhileIsOn()
    {

    }
}
