using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{

    public int maxHp = 5, Hp;
    Rigidbody2D rig;
    Invuln invuln;
    Character_Controller cont;
    Text hpText;
    Boost boost;
    public float boostMultiplyer = 1;
    
    public Vector3 SpawnPoint, RevivePoint;
    public static PlayerHp playerHp;
    public RestShrine restShrine;
    public delegate void Call();
    public event Call Damaged;
    private void Start()
    {
        Hp = maxHp;
        rig = GetComponent<Rigidbody2D>();
        invuln = GetComponent<Invuln>();
        cont = GetComponent<Character_Controller>();
        hpText = GameObject.Find("hp").GetComponent<Text>();
        boost = GetComponent<Boost>();
        syncHp();
        playerHp = this;
    }

    public void TakeDamage(int damage, Vector3 dir)
    {
        Damaged();
        Heal.playerHeal.TakeDamage(damage, dir);
        Hp -= damage;
        syncHp();
        if (Hp <= 0)
        {
            Reincarnate.playerReinc.TriggerAbility();
            return;
        }
        boost.StartBoost(-dir * boostMultiplyer);
        if (Character_Controller.walled)
            cont.unWall();
        invuln.TriggerAbility();
        
    }
    public void Die()
    {
        if (!Character_Controller.javlinOn)
        {
            Character_Controller.javlinOn = true;
            Throw.thrown = false;
            Destroy(GameObject.FindGameObjectWithTag("javlin"));
        }
        syncHp();
        Revive();
    }

    public void HealHp(int points)
    {
        if (Hp + points <= maxHp)
        {
            Hp += points;
        }
        else Hp = maxHp;
        syncHp();
    }
    public void respawn(Vector3 point)
    {
        invuln.ForceEnding();
        if (Character_Controller.walled)
            cont.unWall();
        if (!Character_Controller.javlinOn)
        {
            Character_Controller.javlinOn = true;
            Throw.thrown = false;
            Destroy(GameObject.FindGameObjectWithTag("javlin"));
        }
        transform.position = point;
        rig.velocity = Vector2.zero;
        print("respawn");
    }
    void Revive()
    {
        if (restShrine)
        {
            respawn(restShrine.transform.position);
            restShrine.ActivateInteraction();
        }
        else
        {
            respawn(SpawnPoint);
            Hp = maxHp;
            syncHp();
        }

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
    public void syncHp()
    {
        hpText.text = "";
        for (int i = 0; i < Hp; i++)
        {
            hpText.text += "<3 ";
        }
    }
}
