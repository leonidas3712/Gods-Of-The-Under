﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{

    public int maxHp = 5, Hp;
    Rigidbody2D rig;
    Invuln invuln;
    Character_Controller cont;
    Javlin javlin;
    Text hpText;
    Boost boost;

    Vector3 SpawnPoint, RevivePoint;
    [SerializeField]

    private void Start()
    {
        Hp = maxHp;
        rig = GetComponent<Rigidbody2D>();
        invuln = GetComponent<Invuln>();
        cont = GetComponent<Character_Controller>();
        javlin = GetComponent<Javlin>();
        hpText = GameObject.Find("hp").GetComponent<Text>();
        boost = GetComponent<Boost>();
        syncHp();
    }
    public void TakeDamage(int damage, Vector3 dir)
    {
        Hp -= damage;
        boost.StartBoost(-dir);
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
    }
    public void TakeDamage(int damage, Vector3 dir, bool resp)
    {
        Hp -= damage;
        boost.StartBoost(-dir);

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
