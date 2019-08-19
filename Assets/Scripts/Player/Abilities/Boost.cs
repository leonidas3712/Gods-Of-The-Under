using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : Ability
{
    Vector2 boostDirection;
    Rigidbody2D rig;
    public float boostStrength, drag = 0.3f;
    public void StartBoost(Vector2 dir)
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
        rig.velocity += boostDirection*boostStrength;
        AirDrag.PlayerDrag.SetDragPofile(drag,0);
    }
    public override void Finish()
    {
        Gravity.playerGravity.ToggleGravity();
    }
    public override void WhileIsOn()
    {

    }
}
