using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{

    public int maxHp = 5, Hp;
    public bool KnockBack_On;
    Rigidbody2D rig;
    Invuln invuln;
    Character_Controller cont;
    Javlin javlin;
    Text hpText;

    Vector3 SpawnPoint, RevivePoint;
    [SerializeField]
    float KnockBack_Length = 0.15f, KnockBack_Strength = 10, timer = 0;

    private void Start()
    {
        Hp = maxHp;
        rig = GetComponent<Rigidbody2D>();
        invuln = GetComponent<Invuln>();
        cont = GetComponent<Character_Controller>();
        javlin = GetComponent<Javlin>();
        hpText = GameObject.Find("hp").GetComponent<Text>();
        syncHp();
    }
    public void TakeDamage(int damage, Vector3 dir)
    {
        Hp -= damage;
        KnockBack(dir);
        if (Hp <= 0)
        {
            if (!javlin.javlinOn)
            {
                javlin.javlinOn = true;
                Throw.thrown = false;
                Destroy(GameObject.FindGameObjectWithTag("javlin"));
            }
            Revive();
        }
        if (Character_Controller.walled)
            cont.unWall();
        invuln.condition = true;
        syncHp();
        if (Character_Controller.anim.GetBool("Rodeo"))
            cont.EndRodeo();
    }
    public void TakeDamage(int damage, Vector3 dir, bool resp)
    {
        Hp -= damage;
        KnockBack(dir);

        if (Character_Controller.walled)
            cont.unWall();
        if (!javlin.javlinOn)
        {
            javlin.javlinOn = true;
            Throw.thrown = false;
            Destroy(GameObject.FindGameObjectWithTag("javlin"));
        }
        if (Hp <= 0)
        {
            Revive();
            return;
        }
        respawn(SpawnPoint);
        syncHp();
    }
    public void Heal(int points)
    {
        if (Hp + points <= maxHp)
        {
            Hp += points;
            syncHp();
        }

    }

    public void KnockBack(Vector3 dir)
    {
        KnockBack_On = true;
        rig.gravityScale = 0;
        timer = Time.time + KnockBack_Length;
        rig.velocity = -dir * KnockBack_Strength;
    }

    void respawn(Vector3 point)
    {
        transform.position = point;
        rig.velocity = Vector2.zero;
        print("respawn");
    }
    void Revive()
    {
        Hp = maxHp;
        respawn(RevivePoint);
        syncHp();
    }
    private void FixedUpdate()
    {
        if (timer <= Time.time && KnockBack_On)
        {
            //starts slowing down
            rig.gravityScale = Character_Controller.GravityScale;
            if (rig.velocity.x > 0)
                rig.velocity = new Vector2(rig.velocity.x - 0.8f, rig.velocity.y);
            else
                rig.velocity = new Vector2(rig.velocity.x + 0.8f, rig.velocity.y);
            //stop the knockback when veloctiy hits below walking speed
            if (Mathf.Abs(rig.velocity.x) <= Character_Controller.speed)
            {
                KnockBack_On = false;
            }
        }

    }
    private void Update()
    {
        invuln.DelayedAction();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "RevivePoint")
        {
            RevivePoint = coll.transform.position;
            SpawnPoint = RevivePoint;
        }
        if (coll.tag == "SpawnPoint")
        {
            SpawnPoint = coll.transform.position;
        }
    }
    void syncHp()
    {
        hpText.text = "";
        for (int i = 0; i < Hp; i++)
        {
            hpText.text += "<3 ";
        }
    }
}
