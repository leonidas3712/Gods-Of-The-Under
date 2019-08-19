using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_With_charge : Ability
{
    Rigidbody2D rig;
    public GameObject javlin;
    public static bool thrown;
    Boost boost;
    [SerializeField]
    float dis = 2;
    Camera cam;
    public int damage = 1;

    [SerializeField]
    float flight_speed = 20, KnockBack_Strength = 20, start_flight_speed = 20, start_KnockBack_Strength = 1, flight_speed_growth = 0.2f, knockBack_Growth = 0.001f;


    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rig = GetComponent<Rigidbody2D>();
        boost = GetComponent<Boost>();
        maxTimes = 1;
        canInterrupt = false;
        isInterruptable = false;
    }

    public override bool Condition()
    {
        return base.Condition() && Character_Controller.javlinOn;
    }
    public override void CheckInput()
    {
        if (Input.GetMouseButtonDown(1)) inputTimer = Time.time + inputTriggerTime;
    }
    public override void Update()
    {
        base.Update();
        if (Gravity.grounded && timesDone == 1 /*&& GetComponent<Javlin>().javlinOn*/)
        {
            ResetTimesDone();
        }
    }
    public override void Action()
    {
        flight_speed = start_flight_speed;
        KnockBack_Strength = start_KnockBack_Strength;
    }
    public override void WhileIsOn()
    {
        if (Input.GetMouseButtonUp(1))
        {
            ForceEnding();
        }
        else
        {
            flight_speed += flight_speed_growth;
            KnockBack_Strength += knockBack_Growth;
        }
    }

    public override void Finish()
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
