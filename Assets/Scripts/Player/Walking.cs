using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    public float acceleration = 2, maxVelocity = 7, drag = 1;
    Rigidbody2D rig;
    public static Walking playerWalking;
    Vector2 walkingDir;
    private void Awake()
    {
        playerWalking = this;
    }
    private void Start()
    {
        PlayerInput.playerActions.Player.Walking.performed += SetWalkingDir;
        PlayerInput.playerActions.Player.Walking.canceled += zeroDir;

        Gravity.playerGravity.groundCall += new Gravity.GroundCall(setDrag);
        rig = GetComponent<Rigidbody2D>();
    }
    void SetWalkingDir(InputAction.CallbackContext context)
    {
        walkingDir = context.ReadValue<Vector2>();
        if (walkingDir.x > 0) walkingDir = Vector2.right;
        else
        if (walkingDir.x <= 0) walkingDir = Vector2.left;
    }
    void zeroDir(InputAction.CallbackContext context)
    {
        walkingDir = Vector2.zero;
    }
    public void Walk()
    {
        if (walkingDir == Vector2.left)
        {
            if (rig.velocity.x > -maxVelocity)
            {
                MoveHorizontaly(-acceleration);
            }
            //else if (rig.velocity.x != -maxVelocity) rig.velocity = new Vector2(-maxVelocity, rig.velocity.y);
        }
        else
        if (walkingDir == Vector2.right)
        {
            if (rig.velocity.x < maxVelocity)
            {
                MoveHorizontaly(acceleration);
            }
            //else if (rig.velocity.x != maxVelocity) rig.velocity = new Vector2(maxVelocity, rig.velocity.y);
        }

        if ((walkingDir != Vector2.zero) && Mathf.Abs(rig.velocity.x) <= maxVelocity)
        {
            AirDrag.PlayerDrag.SetDragPofile(drag, 0);
        }
    }

    void setDrag()
    {
        AirDrag.PlayerDrag.SetDragPofile(drag, 0);
    }
    void MoveHorizontaly(float acc)
    {
        float sign = acc / Mathf.Abs(acc);
        if (Mathf.Abs(rig.velocity.x) + Mathf.Abs(acc) > maxVelocity && rig.velocity.x * sign >= 0)
        {
            rig.velocity = new Vector2(maxVelocity * sign, rig.velocity.y);
        }
        else
        {
            if (rig.velocity.x * sign <= 0 && Mathf.Abs(rig.velocity.x) <= maxVelocity && Gravity.grounded)
                rig.velocity *= Vector2.up;
            rig.velocity = new Vector2(acc + rig.velocity.x, rig.velocity.y);
        }
    }
}
