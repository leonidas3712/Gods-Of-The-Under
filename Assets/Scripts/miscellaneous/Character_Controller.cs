using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public static bool grounded, walled, HasWallStick, HasThrow;
    public static float GravityScale;
    public static float speed = 7;
    public static Animator anim;
    Charge charge;
    Strong_Charge strongCharge;
    Jump jump;
    Javlin javlin;
    PlayerHp playerHp;
    public static Rigidbody2D rig;

    Collision2D contactedColl;

    Vector3 wallOffset, correctPosition;
    GameObject stuckedOnWall, hitbox, targetLink;

    float stateNormTime;
    bool suckedLife;

    float colliderHight, colliderWidth;
    int layermask;
    RaycastHit2D[] hitarr;

    private void Start()
    {
        layermask = ~(LayerMask.GetMask("Player", "Ignore Raycast"));
        HasThrow = true;
        HasWallStick = true;
        charge = GetComponent<Charge>();
        strongCharge = GetComponent<Strong_Charge>();
        jump = GetComponent<Jump>();
        javlin = GetComponent<Javlin>();
        rig = GetComponent<Rigidbody2D>();
        GravityScale = rig.gravityScale;
        playerHp = GetComponent<PlayerHp>();
        anim = GetComponent<Animator>();
        hitbox = transform.GetChild(0).gameObject;
        colliderHight = GetComponent<Collider2D>().bounds.size.y;
        colliderWidth = GetComponent<Collider2D>().bounds.size.x;
    }

    /* private void OnCollisionEnter2D(Collision2D coll)
     {

        if (coll.GetContact(0).normal == Vector2.up || coll.collider.tag == "javlin"&&!hitbox.activeInHierarchy&& !playerHp.KnockBack_On)
         {
             grounded = true;
             //anim.SetBool("grounded", true);
             contactedColl = coll;
         }

     }
     public void OnCollisionExit2D(Collision2D coll)
     {

         if (contactedColl.GetContact(0).normal == Vector2.up && contactedColl.collider == coll.collider || coll.collider.tag == "javlin")
         {
             grounded = false;
             // anim.SetBool("grounded", false);

         }
     }*/

    void OnCollisionStay2D(Collision2D coll)
    {
        if (grounded == false)
        {

            if (coll.collider.tag == "javlin")
            {
                //anim.SetBool("grounded", true);
                grounded = true;
            }
            /* else
                 foreach (ContactPoint2D contactPoint in coll.contacts)
                 {
                     if (contactPoint.normal == Vector2.up)
                     {
                         //anim.SetBool("grounded", true);
                         contactedColl = coll;
                         grounded = true;
                         break;
                     }
                 }*/
        }
        if (coll.collider.tag == "foe") playerHp.TakeDamage(1, HelpfulFuncs.Norm1(coll.collider.transform.position - transform.position));

    }
    void GroundCheck()
    {
        grounded = false;
        hitarr = new RaycastHit2D[3];
        hitarr[0] = Physics2D.Raycast(transform.position, Vector2.down, colliderHight / 2 + 0.1f, layermask);
        hitarr[1] = Physics2D.Raycast(transform.position + (Vector3)Vector2.right * colliderWidth / 2, Vector2.down, colliderHight / 2 + 0.1f, layermask);
        hitarr[2] = Physics2D.Raycast(transform.position + (Vector3)Vector2.left * colliderWidth / 2, Vector2.down, colliderHight / 2 + 0.1f, layermask);
        foreach (RaycastHit2D hit in hitarr)
        {
            if (hit.collider && (hit.normal == Vector2.up || hit.collider.tag == "javlin"))
            {
                grounded = true;
                break;
            }
        }
    }
    private void Update()
    {
        if (anim.GetBool("Rodeo"))
            Rodeo();
        else
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
            if (strongCharge.isCharging)
                strongCharge.Charging();
            else
            {
                if (!Throw.KnockBack_On && !playerHp.KnockBack_On)
                {
                    GroundCheck();
                    Movement();
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

    public void BeginRodeo(GameObject wall, Vector3 dir)
    {

        stuckedOnWall = wall;
        rig.gravityScale = 0;
        rig.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1);
        targetLink = new GameObject();
        targetLink.transform.position = transform.position;
        targetLink.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
        targetLink.transform.parent = wall.transform;
    }

    void Rodeo()
    {
        if (!Input.GetKey("left shift"))
        {
            EndRodeo();
            return;
        }

        stateNormTime = anim.GetCurrentAnimatorStateInfo(0).normalizedTime - (int)anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (!stuckedOnWall || !stuckedOnWall.activeSelf)
        {
            EndRodeo();
            return;
        }

        if (stateNormTime > 0.9 && stateNormTime < 1 && !suckedLife && playerHp.Hp < playerHp.maxHp)
        {
            suckedLife = true;
            playerHp.Heal(1);
            stuckedOnWall.GetComponent<HP>().TakeDamage(1, Vector3.zero);
            if (suckedLife && playerHp.Hp == playerHp.maxHp)
            {
                EndRodeo();
                return;
            }
        }
        if (suckedLife && stateNormTime < 0.9)
            suckedLife = false;
        transform.position = targetLink.transform.position;
        transform.rotation = Quaternion.Euler(targetLink.transform.rotation.eulerAngles);
        /*correctPosition = stuckedOnWall.transform.position + wallOffset;
        if (transform.position != correctPosition) transform.position = correctPosition;*/
    }

    public void EndRodeo()
    {
        anim.SetBool("Rodeo", false);
        if (targetLink) Destroy(targetLink);
        rig.gravityScale = GravityScale;
        playerHp.KnockBack(HelpfulFuncs.Norm1( stuckedOnWall.transform.position-transform.position)*2);
        transform.rotation = Quaternion.Euler(0, 0, 0);

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

    void Movement()
    {
        //right
        if (Input.GetKey("a"))
        {
            rig.velocity = new Vector2(-speed, rig.velocity.y);
            //anim.SetBool("isRunning", true);
        }
        else if (Input.GetKey("d"))
        {
            rig.velocity = new Vector2(speed, rig.velocity.y);
            //anim.SetBool("isRunning", true);
        }
        else if (!Input.GetKey("a") && !Input.GetKey("d") /*&& grounded*/)
        {
            //anim.SetBool("isRunning", false);
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
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
