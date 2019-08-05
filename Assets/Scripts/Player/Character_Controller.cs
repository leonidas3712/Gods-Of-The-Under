using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public static bool  walled, HasWallStick, HasThrow;
    public static Animator anim;
    Charge charge;
    Jump jump;
    Javlin javlin;
    PlayerHp playerHp;
    public static Walking walking;
    public static Rigidbody2D rig;
    public static Gravity gravity;

    Collision2D contactedColl;

    Vector3 wallOffset, correctPosition;
    GameObject stuckedOnWall, hitbox, targetLink;

    float stateNormTime;
    bool suckedLife;

    private void Start()
    {
        HasThrow = true;
        HasWallStick = true;
        charge = GetComponent<Charge>();
        jump = GetComponent<Jump>();
        javlin = GetComponent<Javlin>();
        rig = GetComponent<Rigidbody2D>();
        playerHp = GetComponent<PlayerHp>();
        anim = GetComponent<Animator>();
        walking = GetComponent<Walking>();
        gravity = GetComponent<Gravity>();
        hitbox = transform.GetChild(0).gameObject;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.tag == "foe") playerHp.TakeDamage(1, HelpfulFuncs.Norm1(coll.collider.transform.position - transform.position));

    }
    private void Update()
    {
        if (walled)
            wallControls();
        else
            mainControl();

        Flip();

        /*if (rig.velocity.y > 0)
            anim.SetInteger("vertiVel", 1);
        if (rig.velocity.y == 0)
            anim.SetInteger("vertiVel", 0);
        if (rig.velocity.y < 0)
            anim.SetInteger("vertiVel", -1);*/
    }

    void mainControl()
    {
        if (!charge.AbilityOn)
            {
                if (!Throw.KnockBack_On && !playerHp.KnockBack_On)
                {
                    gravity.GroundCheck();
                    walking.Walk();
                    jump.DelayedAction();
                }

                //javelin crap*******
                if (javlin.javlinOn)
                    charge.DelayedAction();
                //if the javlin is equiped you may throw
                if (Input.GetMouseButtonDown(1) && javlin.javlinOn)
                    javlin.ExecuteThrow();
                else
                if (Input.GetKeyDown("e") && !javlin.javlinOn)
                {
                    javlin.ExecuteCallBack();
                }
                //*******************

            }
        if (javlin.javlinOn || charge.AbilityOn)
            charge.DelayedAction();
    }

    void wallControls()
    {
        if (!charge.AbilityOn)
            jump.DelayedAction();
        charge.DelayedAction();
        correctPosition = stuckedOnWall.transform.position + wallOffset;
        if (transform.position != correctPosition) transform.position = correctPosition;
        if (!stuckedOnWall.activeInHierarchy) unWall();
    }
    public void stickToWall(GameObject wall)
    {
        //anim.SetBool("isWalled", true);
        walled = true;
        charge.ResetTimesDone();
        jump.ResetTimesDone();
        //rig.bodyType = RigidbodyType2D.Static;
        rig.gravityScale = 0;
        rig.velocity = Vector2.zero;
        //GetComponent<Collider2D>().isTrigger = true;
        if (charge.wallDiraction == Vector2.right)
            transform.rotation = Quaternion.Euler(0, 0, -90);
        else
            transform.rotation = Quaternion.Euler(0, 0, 90);
        wallOffset = transform.position - wall.transform.position;
        stuckedOnWall = wall;
    }
    public void unWall()
    {
        //anim.SetBool("isWalled", false);
        walled = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //rig.bodyType = RigidbodyType2D.Dynamic;
        //GetComponent<Collider2D>().isTrigger = false;
    }

    void Flip()
    {
        if (Input.anyKeyDown)
        {
            if (rig.velocity.x > 0)
            {
                if (transform.localScale.x < 0)
                {

                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }

            }

            else if (rig.velocity.x < 0)
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }

        }
    }
}
