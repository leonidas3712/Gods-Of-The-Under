using System.Collections;
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
    Charge charge;
    public static Jump playerJump;
    private void Awake()
    {
        playerJump = this;
    }
    void Start()
    {
        Gravity.playerGravity.groundCall += new Gravity.GroundCall(reCharge);
        playerAbilities = GetComponents<Ability>();
        input = "space";
        rig = GetComponent<Rigidbody2D>();
        invuln = GetComponent<Invuln>();
        charge = GetComponent<Charge>();
    }
    public override bool Condition()
    {
        return base.Condition() && (Gravity.grounded || Character_Controller.walled);
    }

    public override void Action()
    {
        timesDone++;
        jumped = true;
        if (Input.GetKey("a"))
            rig.velocity = new Vector2(-Walking.playerWalking.maxVelocity-2, jumpSpeed-2f);
        else if (Input.GetKey("d"))
            rig.velocity = new Vector2(Walking.playerWalking.maxVelocity+2, jumpSpeed-2f);
        else
            rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
        AirDrag.PlayerDrag.SetDragPofile(0.15f, 0);
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
                rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y / 2);
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

    void reCharge()
    {
        ResetTimesDone();
        jumped = false;
    }

}
