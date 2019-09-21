using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump_PreCharge : Ability
{
    Ability[] playerAbilities;
    Rigidbody2D rig;
    [SerializeField]
    float maxJumpSpeed = 7, drag;
    public bool jumped;
    float jumpModifier, jumpSpeed;
    public static Jump_PreCharge playerJump;
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
        playerAbilities = GetComponents<Ability>();
        rig = GetComponent<Rigidbody2D>();

    }
    public override bool Condition()
    {
        return base.Condition() && (Gravity.grounded || Character_Controller.walled);
    }

    public override void Finish()
    {
        timesDone++;
        jumped = true;
        jumpSpeed = maxJumpSpeed * ((length - timeLeft) / length);

        if (Input.GetKey("a"))
            rig.velocity = new Vector2(-Walking.playerWalking.maxVelocity - 2, jumpSpeed - 2f);
        else if (Input.GetKey("d"))
            rig.velocity = new Vector2(Walking.playerWalking.maxVelocity + 2, jumpSpeed - 2f);
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
