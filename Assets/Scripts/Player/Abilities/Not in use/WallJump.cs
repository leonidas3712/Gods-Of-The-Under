using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallJump : Ability
{
    Rigidbody2D rig;
    [SerializeField]
    float jumpSpeed = 7, drag;
    public bool jumped;
    bool walled;
    public static WallJump playerJump;
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
    public override bool Condition()
    {
        return base.Condition() && (walled);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.GetContact(0).normal == Vector2.left || coll.GetContact(0).normal == Vector2.left) walled = true;
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        walled = false;
    }
    public override void Action()
    {
        jumped = true;
        if (Input.GetKey("a"))
            rig.velocity = new Vector2(-Walking.playerWalking.groundMaxVelocity - 2, jumpSpeed - 2f);
        else if (Input.GetKey("d"))
            rig.velocity = new Vector2(Walking.playerWalking.groundMaxVelocity + 2, jumpSpeed - 2f);
        else
            rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
        AirDrag.PlayerDrag.SetDragPofile(drag, 0);
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
