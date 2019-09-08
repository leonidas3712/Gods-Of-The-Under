using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Charge : Ability
{

    Rigidbody2D rig;
    GameObject cam;
    GameObject hitBox;
    GameObject wall;
    Vector3 aimDir, strikenFoeDir;
    public Vector2 wallDiraction, bounceDir,preChargeVel;
    Strike javlinStrike;
    //whether the charge input where pressed the intire charge or not
    public bool inputCheck, isWalled, striked, strikedFoe;
    //soposed to fix disync in collision enter
    [SerializeField]
    float curDamage;
    public float ChargeMovmentSpeed, baseDamage = 2, knockBackMult = 1;
    PlayerHp hp;
    Character_Controller charController;
    Boost boost;
    Throw throwAbility;
    Throw_Bow bow;
    bool isDownDash;
    public static Charge playerCharge;
    private void Awake()
    {
        playerCharge = this;

    }
    private void Start()
    {
        PlayerInput.playerActions.Player.Charge.performed += CheckInput;

        Gravity.playerGravity.groundCall += new Gravity.GroundCall(ResetTimesDone);
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
        throwAbility = GetComponent<Throw>();
        bow = GetComponent<Throw_Bow>();
    }
    void SetAimDir(InputAction.CallbackContext context)
    {
        aimDir = context.ReadValue<Vector2>();
        print(aimDir);
    }
    public override void Action()
    {
        preChargeVel = rig.velocity;
        striked = false;
        isDownDash = false;
        //Character_Controller.anim.SetBool("isCharging", true);
        if (Input.GetMouseButtonDown(0)) inputCheck = true;
        timesDone++;
        Gravity.playerGravity.ToggleGravity(false);

        AirDrag.dragActive = false;

        //this segment will be changed after controller input will be implemented***
        aimDir = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        aimDir = HelpfulFuncs.Norm1(aimDir - transform.position) * ChargeMovmentSpeed;
        //***

        //if the charge is set downwards
        if (aimDir.y < 0)
            //if josie is on the ground
            if (Gravity.grounded)
            {
                //take the y value off the direction vector
                aimDir = new Vector3(aimDir.x, 0, 0);
            }
        //if you are trying to charge into a wall 
        if (Character_Controller.walled)
        {
            if ((aimDir.x > 0 && wallDiraction == Vector2.left) || (aimDir.x < 0 && wallDiraction == Vector2.right))
            {
                if (aimDir.y >= 0)
                    aimDir = new Vector3(0, ChargeMovmentSpeed, 0);
                else
                    aimDir = new Vector3(0, -ChargeMovmentSpeed, 0);

            }
            GetComponent<Character_Controller>().unWall();
        }
        rig.velocity =HelpfulFuncs.Norm1(rig.velocity)*2+ aimDir;
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
            Gravity.playerGravity.ToggleGravity(true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rig.velocity *= 0.3f;
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
        if ((Input.GetMouseButton(0)) && angle > 50 && angle < 130)
        {
            if (timeLeft < 0.05f)
            {
                timer += 0.05f;
                isDownDash = true;
            }
            if (isDownDash)
            {
                aimDir = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
                aimDir = HelpfulFuncs.Norm1(aimDir - transform.position) * ChargeMovmentSpeed;
                rig.velocity = aimDir;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg * -1);
    }
    public void hitBoxCall(Collision2D coll, bool parryActive)
    {
        if (AbilityOn)
        {
            if (parryActive)
            {
                if (coll.collider.tag == "hitBox")
                {
                    //((Vector2)(coll.transform.position - transform.position)-coll.GetContact(0).normal*30)
                    strike((Vector2)(coll.transform.position - transform.position) - Vector2.up * 1.8f);
                    GameObject parryEffect = (GameObject)Instantiate(Resources.Load("hitClash"), coll.GetContact(0).point, Quaternion.Euler(180, 0, 0));
                    Destroy(parryEffect, 0.6f);
                    ForceEnding();
                    return;
                }
            }
            if (coll.collider.tag == "foe" || coll.collider.tag == "hitBox")
            {
                strike((Vector2)(coll.transform.position - transform.position) - Vector2.up * 1.8f);
                strikedFoe = true;
                javlinStrike.Hit(coll.collider.gameObject);
                ForceEnding();
                return;
            }
            else
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
                ForceEnding();
            }
        }

    }
    void strike(Vector2 dir)
    {
        ResetTimesDone();
        throwAbility.ResetTimesDone();
        bow.ResetTimesDone();
        striked = true;
        strikenFoeDir = HelpfulFuncs.Norm1(dir);
    }
}
