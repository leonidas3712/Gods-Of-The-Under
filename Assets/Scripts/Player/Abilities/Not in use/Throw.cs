using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : Ability
{
    Rigidbody2D rig;
    public GameObject javlin;
    public static bool thrown;
    Boost boost;
    [SerializeField]
    float dis = 2;
    Camera cam;
    public int damage = 1;
    public static Throw playerThrow;
    [SerializeField]
    float flight_speed = 20, KnockBack_Strength = 20;

    private void Awake()
    {
        if (enabled)
        {
            PlayerInput.playerActions.Player.Throw.performed += CheckInput;
        }
    }
    private void Start()
    {
        Gravity.playerGravity.groundCall += new Gravity.GroundCall(ResetTimesDone);
        playerThrow = this;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rig = GetComponent<Rigidbody2D>();
        boost = GetComponent<Boost>();
        maxTimes = 1;
        canInterrupt = true;
        isInterruptable = false;
    }

    public override bool Condition()
    {
        return base.Condition() && Character_Controller.javlinOn;
    }

    public override void Action()
    {
        //finds mouse position
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        Vector3 pos = transform.position;
        //will be changed in controller input
        mouse = HelpfulFuncs.Norm1(mouse - pos);

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
