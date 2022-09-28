using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reincarnate : Ability
{
    Rigidbody2D rig;
    public GameObject javlin;
    public static Reincarnate playerReinc;
    bool thrown;
    [SerializeField]
    Camera cam;
    [SerializeField]
    float flight_speed = 20;
    Vector3 mouse;
    private void Awake()
    {
        playerReinc = this;
    }
    private void Start()
    {
        PlayerInput.playerActions.Player.Reincarnetion.performed += CheckInput;
        PlayerInput.playerActions.Player.Charge.performed += Hurl;
        rig = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public override void Action()
    {
        rig.bodyType = RigidbodyType2D.Static;
        if (!Character_Controller.javlinOn)
        {
            Character_Controller.javlinOn = true;
            Throw_Bow.thrown = false;
            Destroy(GameObject.FindGameObjectWithTag("javlin"));
        }
    }
    public void Hit(Vector3 targetPosition)
    {
        transform.position = targetPosition;
        Charge.playerCharge.ResetTimesDone();
        Throw_Bow.playerThrow_Bow.ResetTimesDone();
        ForceEnding();
    }
    public override void Interrupt()
    {
        timer = 0;
        timer = Time.time + intervals;
        AbilityOn = false;
        rig.bodyType = RigidbodyType2D.Dynamic;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        thrown = false;
    }
    public override void Finish()
    {
        thrown = false;
        rig.bodyType = RigidbodyType2D.Dynamic;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rig.velocity = Vector2.up * 3;
        PlayerHp.playerHp.TakeDamage(1, Vector3.zero, false);
    }
    public override void WhileIsOn()
    {
        mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        float dis = Vector2.Distance(transform.position, mouse);
        mouse -= transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.x, mouse.y) * Mathf.Rad2Deg * -1);
    }

    void Hurl(InputAction.CallbackContext con)
    {
        if (!AbilityOn || thrown) return;
        thrown = true;
        mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        Vector3 pos = transform.position;
        //will be changed in controller input
        mouse = HelpfulFuncs.Norm1(mouse - pos);

        transform.rotation = Quaternion.Euler(0, 0, 0);

        //the position in which the spear will apear
        pos = new Vector3(pos.x + mouse.x * 2f, pos.y + mouse.y * 2f, 0);

        //************************************************throw the javlin part************************************************
        javlin = (GameObject)Instantiate(Resources.Load("prototype1"), pos, Quaternion.Euler(0, 0, Mathf.Atan2(mouse.x, mouse.y) * Mathf.Rad2Deg * -1));
        javlin.GetComponent<Rigidbody2D>().velocity = mouse * flight_speed;
    }
}
