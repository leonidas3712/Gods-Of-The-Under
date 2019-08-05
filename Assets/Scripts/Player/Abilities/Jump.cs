using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability
{
    Ability[] playerAbilities;
    Rigidbody2D rig;
    [SerializeField]
    float jump_speed = 7;
    public bool jumped, interapted;
    int twoFramesTimer = 3;

    void Start()
    {
        playerAbilities = GetComponents<Ability>();
        input = "space";
        rig = GetComponent<Rigidbody2D>();
    }

    public override void Action()
    {

        if (!Gravity.grounded && !Character_Controller.walled)
        {
            ForceEnding();
            return;
        }
        interapted = false;
        timesDone++;
        jumped = true;
        rig.velocity = new Vector2(rig.velocity.x, jump_speed);
        Gravity.playerGravity.ToggleGravity(false);
        //needs to happen after physical staff is done so it wont touch the wall while its collider returns
        if (Character_Controller.walled)
        {
            GetComponent<Character_Controller>().unWall();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public override void Finish()
    {
        if (jumped && !interapted&& !Character_Controller.walled)
        {
            Gravity.playerGravity.ToggleGravity(true);
            /*if (rig.velocity.y > 0)
                rig.velocity = new Vector2(rig.velocity.x, 0.1f);*/
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
    private void Update()
    {
        /*jumping has the lowest priority so when interapted by other abilities it is the only 
        ability that will call its finish function after the interapting ability has finished*/
        interruptionCheck();
    }
    void interruptionCheck()
    {
        if (AbilityOn)
            foreach (Ability ab in playerAbilities)
            {
                if (ab.AbilityOn && ab != this)
                {
                    interapted = true;
                    break;
                }
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
                    Gravity.playerGravity.ToggleGravity(true);
                    ForceEnding();
                }
                twoFramesTimer = 3;
                ResetTimesDone();
                jumped = false;
            }

        }
    }
}
