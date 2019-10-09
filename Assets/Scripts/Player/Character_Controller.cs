using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public static bool walled, javlinOn = true;
    public bool HasWallStick;
    public static Animator anim;
    public static Character_Controller controller;
    Charge charge;
    Jump jump;
    PlayerHp playerHp;
    public static Walking walking;
    public static Rigidbody2D rig;
    public AirDrag airDrag;
    Collision2D contactedColl;
    Boost boost;
    Ability[] playerAbilities;
    Throw throwAbility;
    Throw_Bow bow;
    CallBack callBack;
    AirJump airJump;
    Jump_PreCharge preJump;
    WallJump wallJump;
    Reincarnate reinc;
    Vector3 wallOffset, correctPosition;
    GameObject stuckedOnWall, hitbox, targetLink;


    float stateNormTime;
    bool suckedLife;


    public delegate void WallReset();
    public event WallReset wallCall;
    private void Awake()
    {
        controller = this;
    }
    private void Start()
    {

        charge = GetComponent<Charge>();
        jump = GetComponent<Jump>();
        rig = GetComponent<Rigidbody2D>();
        playerHp = GetComponent<PlayerHp>();
        anim = GetComponent<Animator>();
        walking = GetComponent<Walking>();
        hitbox = transform.GetChild(0).gameObject;
        airDrag = GetComponent<AirDrag>();
        boost = GetComponent<Boost>();
        playerAbilities = GetComponents<Ability>();
        throwAbility = GetComponent<Throw>();
        callBack = GetComponent<CallBack>();
        airJump = GetComponent<AirJump>();
        bow = GetComponent<Throw_Bow>();
        preJump = Jump_PreCharge.playerJump;
        wallJump = WallJump.playerJump;
        reinc = Reincarnate.playerReinc;
        foreach (Ability ability in playerAbilities)
        {
            ability.triggerInterruptions += new Ability.InterruptionEvent(Interruptions);
        }
    }

    private void Update()
    {
        if (!Reincarnate.playerReinc.AbilityOn)
        {
            if (walled)
                wallControls();
            else
                mainControl();
        }


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
            if (!boost.AbilityOn && !bow.AbilityOn)
            {
                walking.Walk();
                if (preJump.Condition()) preJump.TriggerAbility();
                if (wallJump.Condition()) wallJump.TriggerAbility();
                if (jump.Condition()) jump.TriggerAbility();
                if (airJump.Condition() && !jump.AbilityOn) airJump.TriggerAbility();
            }
            if (throwAbility.Condition()) throwAbility.TriggerAbility();
            if (bow.Condition()) bow.TriggerAbility();

        }
        if (javlinOn && charge.Condition())
            charge.TriggerAbility();
        if (reinc.Condition()) reinc.TriggerAbility();
    }
    void Interruptions()
    {
        foreach (Ability ability in playerAbilities)
        {
            if (ability.AbilityOn && ability.isInterruptable) ability.Interrupt();
        }
    }

    void wallControls()
    {
        if (!charge.AbilityOn)
        {
            if (jump.Condition()) jump.TriggerAbility();
            if (preJump.Condition()) preJump.TriggerAbility();
        }

        if (charge.Condition())
            charge.TriggerAbility();
        correctPosition = stuckedOnWall.transform.position + wallOffset;
        if (transform.position != correctPosition) transform.position = correctPosition;
        if (!stuckedOnWall.activeInHierarchy) unWall();
    }
    public void stickToWall(GameObject wall)
    {
        if (!walled && HasWallStick)
        {
            //anim.SetBool("isWalled", true);
            walled = true;

            wallCall();
            //rig.bodyType = RigidbodyType2D.Static;
            Gravity.playerGravity.ToggleGravity(false);
            rig.velocity = Vector2.zero;
            //GetComponent<Collider2D>().isTrigger = true;
            if (charge.wallDiraction == Vector2.right)
                transform.rotation = Quaternion.Euler(0, 0, -90);
            else
                transform.rotation = Quaternion.Euler(0, 0, 90);
            wallOffset = transform.position - wall.transform.position;
            stuckedOnWall = wall;
        }

    }
    public void unWall()
    {
        if (walled)
        {
            //anim.SetBool("isWalled", false);
            walled = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Gravity.playerGravity.ToggleGravity();
            //rig.bodyType = RigidbodyType2D.Dynamic;
            //GetComponent<Collider2D>().isTrigger = false;
        }

    }


}
