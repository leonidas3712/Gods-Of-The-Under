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
        Gravity.playerGravity.groundCall += new Gravity.GroundCall(setDrag);
        rig = GetComponent<Rigidbody2D>();
    }
    void SetWalkingDir(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() == Vector2.zero) walkingDir = Vector2.zero;
        else
            walkingDir = HelpfulFuncs.Norm1(context.ReadValue<Vector2>());
    }
    public void Walk()
    {
        if (Input.GetKey("a"))
        {
            if (rig.velocity.x > -maxVelocity)
            {
                MoveHorizontaly(-acceleration);
            }
            //else if (rig.velocity.x != -maxVelocity) rig.velocity = new Vector2(-maxVelocity, rig.velocity.y);
        }
        else
          if (Input.GetKey("d"))
        {
            if (rig.velocity.x < maxVelocity)
            {
                MoveHorizontaly(acceleration);
            }
            //else if (rig.velocity.x != maxVelocity) rig.velocity = new Vector2(maxVelocity, rig.velocity.y);
        }

        if ((Input.GetKey("a") || Input.GetKey("d")) && Mathf.Abs(rig.velocity.x) <= maxVelocity)
        {
            AirDrag.PlayerDrag.SetDragPofile(drag, 0);
        }

        /* if (!Input.GetKey("a") && !Input.GetKey("d"))
         {
             if (/*Mathf.Abs(rig.velocity.x) <= maxVelocity + 0.5f || Gravity.grounded) rig.velocity = new Vector2(0, rig.velocity.y);
         }*/

        /* if (walkingDir == Vector2.left)
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
          }*/
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
