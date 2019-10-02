using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump_PreCharge : NonTimedAbility
{
    Rigidbody2D rig;
    [SerializeField]
    float maxJumpSpeed = 7, drag;
    public bool jumped;
    float jumpModifier, jumpSpeed;
    public static Jump_PreCharge playerJump;
    bool inputed;
    private void Awake()
    {
        playerJump = this;
    }
    void Start()
    {
        PlayerInput.playerActions.Player.Jump.performed += CheckInput;
        PlayerInput.playerActions.Player.Jump.canceled += stopJump;
        Character_Controller.controller.wallCall += ResetTimesDone;
        Gravity.playerGravity.groundCall += new Gravity.GroundCall(reCharge);
        rig = GetComponent<Rigidbody2D>();
    }
    public override void CheckInput(InputAction.CallbackContext context)
    {
        inputed = true;
    }
    public override bool Condition()
    {
        bool check = false;
        if (inputed && (!Gravity.grounded || Character_Controller.walled))
        {
            check = true;
            inputed = false;
        }
        return check;
    }

    public override void Finish()
    {

        if (Gravity.grounded)
        {
            jumpSpeed = maxJumpSpeed * ((length - timeLeft) / length);
            if (jumpSpeed > maxJumpSpeed) jumpSpeed = maxJumpSpeed;
            if (Input.GetKey("a"))
                rig.velocity = new Vector2(-Walking.playerWalking.groundMaxVelocity - 7, jumpSpeed - 7f);
            else if (Input.GetKey("d"))
                rig.velocity = new Vector2(Walking.playerWalking.groundMaxVelocity + 7, jumpSpeed - 7f);
            else
                rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
            AirDrag.PlayerDrag.SetDragPofile(drag, 0);

            //needs to happen after physical staff is done so it wont touch the wall while its collider returns
            if (Character_Controller.walled)
            {
                GetComponent<Character_Controller>().unWall();
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    }
    void stopJump(InputAction.CallbackContext context)
    {
        if (AbilityOn)
            ForceEnding();
    }
    void reCharge()
    {
        ResetTimesDone();
        jumped = false;
    }

}
