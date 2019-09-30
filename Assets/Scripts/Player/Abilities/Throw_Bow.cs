using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw_Bow : Ability
{
    Rigidbody2D rig;
    public GameObject javlin;
    public static bool thrown;
    Boost boost;
    [SerializeField]
    float dis = 2;
    Camera cam;
    public int damage = 1;
    public static Throw_Bow playerThrow_Bow;
    [SerializeField]
    float flight_speed = 20, KnockBack_Strength = 20, start_flight_speed = 20, start_KnockBack_Strength = 1, maxWindDistance,airDrag;
    Vector3 mouse;

    private void Awake()
    {
        playerThrow_Bow = this;

    }
    private void Start()
    {
        PlayerInput.playerActions.Player.Throw.performed += CheckInput;
        Gravity.playerGravity.groundCall += new Gravity.GroundCall(ResetTimesDone);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rig = GetComponent<Rigidbody2D>();
        boost = GetComponent<Boost>();
        maxTimes = 1;
    }

    public override bool Condition()
    {
        return base.Condition() && Character_Controller.javlinOn;
    }
    public override void Action()
    {
        flight_speed = start_flight_speed;
        KnockBack_Strength = start_KnockBack_Strength;
       /* Gravity.playerGravity.ToggleGravity(false);
        AirDrag.dragActive = false;*/
        mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        Vector3 pos = transform.position;
        //will be changed in controller input
        mouse = HelpfulFuncs.Norm1(mouse - pos);
        rig.velocity = mouse * 25;
        AirDrag.PlayerDrag.SetDragPofile(airDrag);
    }
    public override void WhileIsOn()
    {
        if (Input.GetMouseButtonUp(1))
        {
            ForceEnding();
        }
        else
        {
            mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
            float dis = Vector2.Distance(transform.position, mouse);
            mouse -= transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.x, mouse.y) * Mathf.Rad2Deg * -1);
            if (dis > maxWindDistance) dis = maxWindDistance;
            flight_speed = start_flight_speed * dis / maxWindDistance;
            KnockBack_Strength = start_KnockBack_Strength * dis / maxWindDistance;
        }
    }
    public override void Interrupt()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        timer = 0;
        timer = Time.time + intervals;
        AbilityOn = false;
        timesDone = 1;
    }
    public override void Finish()
    {

        //finds mouse position
        mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        Vector3 pos = transform.position;
        //will be changed in controller input
        mouse = HelpfulFuncs.Norm1(mouse - pos);

        transform.rotation = Quaternion.Euler(0, 0, 0);

        //the position in which the spear will apear
        pos = new Vector3(pos.x + mouse.x * 2f, pos.y + mouse.y * 2f, 0);
        //you have to be in acertein distence from anything to throw the spear
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouse, 50, 0);
        if (Gravity.grounded)
            if (mouse.y < 0 && hit.distance < dis)
            {

                if (mouse.x >= 0)
                    mouse = new Vector3(1, 0, 0);
                else
                    mouse = new Vector3(-1, 0, 0);
                //do the raycast part all over again
                pos = transform.position;
                pos = new Vector3(pos.x + mouse.x * 2f, pos.y + mouse.y * 2f, 0);
                hit = Physics2D.Raycast(transform.position, mouse, 50, 0);
            }
        if (hit && hit.distance < dis)
            return;

        //************************************************throw the javlin part************************************************
        Character_Controller.javlinOn = false;
        timesDone = 1;
        //spawn the spear
        javlin = (GameObject)Instantiate(Resources.Load("prototype"), pos, Quaternion.Euler(0, 0, Mathf.Atan2(mouse.x, mouse.y) * Mathf.Rad2Deg * -1));
        javlin.GetComponent<Rigidbody2D>().velocity = mouse * flight_speed;
        if (!Gravity.grounded)
            boost.StartBoost(-mouse * KnockBack_Strength);
    }

}
