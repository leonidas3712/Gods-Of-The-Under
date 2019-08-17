using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : Ability
{

    Rigidbody2D rig;
    GameObject cam;
    GameObject hitBox;
    GameObject wall;
    Vector3 mouse, strikenFoeDir;
    public Vector2 wallDiraction, bounceDir;
    Strike javlinStrike;
    //whether the charge input where pressed the intire charge or not
    public bool inputCheck, isWalled, striked, strikedFoe;
    //soposed to fix disync in collision enter
    [SerializeField]
    float curDamage;
    public float ChargeMovmentSpeed, baseDamage = 1, knockBackMult = 1;
    PlayerHp hp;
    Character_Controller charController;
    Boost boost;
    int twoFramesTimer = 3;

    bool isDownDash;

    public override void CheckInput()
    {
        if (Input.GetMouseButtonDown(0)) inputTimer = Time.time + inputTriggerTime;
    }
    private void Start()
    {
        input = "left shift";
        rig = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        curDamage = baseDamage;
        hp = GetComponent<PlayerHp>();
        hitBox = transform.GetChild(0).gameObject;
        hitBox.SetActive(false);
        animator = GetComponent<Animator>();
        charController = GetComponent<Character_Controller>();
        boost = GetComponent<Boost>();
        javlinStrike = GetComponent<Strike>();
    }

    public override void Action()
    {
        striked = false;
        isDownDash = false;
        //Character_Controller.anim.SetBool("isCharging", true);
        if (Input.GetMouseButtonDown(0)) inputCheck = true;
        timesDone++;
        Gravity.playerGravity.ToggleGravity(false);

        AirDrag.dragActive = false;

        //this segment will be changed after controller input will be implemented***
        mouse = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        mouse = HelpfulFuncs.Norm1(mouse - transform.position) * ChargeMovmentSpeed;
        //***

        //if the charge is set downwards
        if (mouse.y < 0)
            //if josie is on the ground
            if (Gravity.grounded)
            {
                //take the y value off the direction vector
                mouse = new Vector3(mouse.x, 0, 0);
            }
        //if you are trying to charge into a wall 
        if (Character_Controller.walled)
        {
            if ((mouse.x > 0 && wallDiraction == Vector2.left) || (mouse.x < 0 && wallDiraction == Vector2.right))
            {
                if (mouse.y >= 0)
                    mouse = new Vector3(0, ChargeMovmentSpeed, 0);
                else
                    mouse = new Vector3(0, -ChargeMovmentSpeed, 0);

            }
            GetComponent<Character_Controller>().unWall();
        }
        rig.velocity = mouse;
        hitBox.SetActive(true);
    }

    public override void Finish()
    {
        hitBox.SetActive(false);
        AirDrag.dragActive = true;
        //wall it up
        if (isWalled)
        {
            isWalled = false;
            inputCheck = false;
            GetComponent<Character_Controller>().stickToWall(wall);
        }
        else
        {
            Gravity.playerGravity.ToggleGravity(true);
            rig.velocity *= 0.3f;

            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (striked)
            {
                boost.StartBoost(-strikenFoeDir * knockBackMult);
            }
            strikedFoe = false;
            //Character_Controller.anim.SetBool("isCharging", false);
        }
    }
    public override void WhileIsOn()
    {
        float angle = Vector2.SignedAngle(rig.velocity, Vector2.right);
        if ((Input.GetMouseButton(0))&& angle > 60 && angle < 120)
        {
            if (timeLeft < 0.05f)
            {
                timer = Time.time + 0.05f;
                isDownDash = true;
            }
            if (isDownDash)
            {
                mouse = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
                mouse = HelpfulFuncs.Norm1(mouse - transform.position) * ChargeMovmentSpeed;
                rig.velocity = mouse;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg * -1);
    }
    public void hitBoxCall(Collision2D coll)
    {
        if (AbilityOn)
        {
            if (coll.collider.tag == "hitBox")
            {
                strike(coll.transform.position - transform.position);
                GameObject parryEffect = (GameObject)Instantiate(Resources.Load("hitClash"), coll.GetContact(0).point, Quaternion.Euler(180, 0, 0));
                Destroy(parryEffect, 0.6f);
                ForceEnding();
            }
            else
            if (coll.collider.tag == "foe")
            {
                strike(coll.transform.position - transform.position);
                strikedFoe = true;
                javlinStrike.Hit(coll.collider.gameObject);
                ForceEnding();
            }
            else
            {
                if (Character_Controller.HasWallStick)
                {
                    Vector2 hitDir = new Vector2(Mathf.Round(coll.GetContact(0).normal.x * 10) / 10, Mathf.Round(coll.GetContact(0).normal.y * 10) / 10);
                    if (hitDir == Vector2.right && rig.velocity.x < 2)
                    {
                        isWalled = true;
                        wallDiraction = Vector2.right;
                        wall = coll.gameObject;
                    }
                    else if (hitDir == Vector2.left && (rig.velocity.x >= -2))
                    {
                        isWalled = true;
                        wallDiraction = Vector2.left;
                        wall = coll.gameObject;
                    }
                }
                ForceEnding();
            }
        }

    }
    void strike(Vector3 dir)
    {
        timesDone = 0;
        striked = true;
        strikenFoeDir = HelpfulFuncs.Norm1(dir);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 hitDir = new Vector2(Mathf.Round(coll.GetContact(0).normal.x * 10) / 10, Mathf.Round(coll.GetContact(0).normal.y * 10) / 10);
        if (hitDir == Vector2.up || coll.collider.tag == "javlin")
        {
            ResetTimesDone();
        }
    }
}
