﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability
{
    Ability[] playerAbilities;
    Rigidbody2D rig;
    [SerializeField]
    float jumpSpeed = 7;
    public bool jumped;
    int twoFramesTimer = 3;
    Invuln invuln;
    void Start()
    {
        playerAbilities = GetComponents<Ability>();
        input = "space";
        rig = GetComponent<Rigidbody2D>();
        invuln = GetComponent<Invuln>();
    }
    public override bool Condition()
    {
        return base.Condition()&&( Gravity.grounded ||Character_Controller.walled);
    }

    public override void Action()
    {
        timesDone++;
        jumped = true;
        rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
        //Gravity.playerGravity.ToggleGravity(false);
        //needs to happen after physical staff is done so it wont touch the wall while its collider returns
        if (Character_Controller.walled)
        {
            GetComponent<Character_Controller>().unWall();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void Finish()
    {
        if (jumped && !Character_Controller.walled)
        {
           // Gravity.playerGravity.ToggleGravity(true);
            if (rig.velocity.y > 0)
                rig.velocity = new Vector2(rig.velocity.x, jumpSpeed/5);
        }
    }
    public override void WhileIsOn()
    {
        if (!Input.GetKey(input))
        {
            //interruptionCheck();
            ForceEnding();
        }
    }

    private void LateUpdate()
    {
        if (Gravity.grounded && jumped)
        {
            //needs to wait about 2 frames after space been pressed for the collision callback to stop accuring
            if (twoFramesTimer > 0)
                twoFramesTimer--;
            else
            {
                if (AbilityOn)
                {
                    //finished is only called in timed action after jumped has been set false
                    //Gravity.playerGravity.ToggleGravity(true);
                    ForceEnding();
                }
                twoFramesTimer = 3;
                ResetTimesDone();
                jumped = false;
            }

        }
    }
}
