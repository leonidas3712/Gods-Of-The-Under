using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strong_Charge : MonoBehaviour
{
    Javlin javlin;
    Rigidbody2D rig;
    string input = "left shift";
    public bool isCharging,isWalled;
    float curDamage, timer, baseSpeed;
    [SerializeField]
    float baseDamage = 1, chargingTime = 0.5f;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        curDamage = baseDamage;
        baseSpeed = GetComponent<Charge>().ChargeMovmentSpeed;
        javlin = GetComponent<Javlin>();
    }
    //called either on charge or when charging from a wall
    public void StartCharge(Vector3 dir)
    {
        //Character_Controller.anim.SetBool("isCharging", true);
        rig.velocity = dir;
        isCharging = true;
        //set the acceleration timer on
        timer = Time.time + chargingTime;
        rig.gravityScale = 0;
    }
    public void EndCharge()
    {
        rig.gravityScale = Character_Controller.GravityScale;
        rig.velocity = Vector2.zero;
        isCharging = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //Character_Controller.anim.SetBool("isCharging", false);
    }
    //called in character controllers
    public void Charging()
    {
        if (!Input.GetKey(input))
        {
            EndCharge();
        }

        //set higher damage if a certein amount of time has passed
        if (timer <= Time.time)
        {
            curDamage = baseDamage * 2;
            rig.velocity *= 1.2f;
        }

        //rotate
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rig.velocity.x, rig.velocity.y) * Mathf.Rad2Deg * -1);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //also deal damage
        if (isCharging)
        {
            if (coll.collider.tag == "foe")
            {
                javlin.ExecuteStrike(coll.collider.gameObject);
            }
            else
            {
                if (coll.GetContact(0).normal == Vector2.right && rig.velocity.x < 2)
                {
                    isCharging = false;
                    GetComponent<Charge>().wallDiraction = Vector2.right;
                    //GetComponent<Character_Controller>().stickToWall();
                }
                else if (coll.GetContact(0).normal == Vector2.left && (rig.velocity.x >= -2))
                {
                    isCharging = false;
                    GetComponent<Charge>().wallDiraction = Vector2.left;
                    //GetComponent<Character_Controller>().stickToWall();
                }
                else
                    EndCharge();
            }

        }

    }

}
