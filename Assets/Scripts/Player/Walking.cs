using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    public float groundAccelartion, airAccelartion, airMaxVelocity, groundMaxVelocity, drag;

    float acceleration = 2,maxVelocity;
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

        if ((walkingDir != Vector2.zero) && Mathf.Abs(rig.velocity.x) <= maxVelocity&&!Gravity.grounded)
        {
            AirDrag.PlayerDrag.SetDragPofile(drag, 0);
        }
    }

    private void Update()
    {
        if (Gravity.grounded) acceleration = groundAccelartion;
        else acceleration = airAccelartion;
        if (Gravity.grounded) maxVelocity = groundMaxVelocity;
        else maxVelocity = airMaxVelocity;

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
