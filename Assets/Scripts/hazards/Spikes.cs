﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private void OnCollisionStay2D(Collision2D coll)
    {
        GameObject victem = coll.collider.gameObject;
        if (victem.GetComponent<HP>())
        {
            victem.GetComponent<HP>().TakeDamage(1,HelpfulFuncs.Norm1(coll.GetContact(0).point-(Vector2)victem.transform.position));
        }
        if (victem.GetComponent<PlayerHp>())
        {
            victem.GetComponent<PlayerHp>().TakeDamage(1, HelpfulFuncs.Norm1(coll.GetContact(0).point - (Vector2)victem.transform.position));
            victem.GetComponent<PlayerHp>().respawn(victem.GetComponent<PlayerHp>().SpawnPoint);
        }
        if(victem.GetComponentInParent<PlayerHp>())
        {
            victem.GetComponentInParent<PlayerHp>().TakeDamage(1, HelpfulFuncs.Norm1(coll.GetContact(0).point - (Vector2)victem.transform.position));
            victem.GetComponentInParent<PlayerHp>().respawn(victem.GetComponentInParent<PlayerHp>().SpawnPoint);
        }
        else if (victem.tag == "javlin")
        {
            victem.GetComponent<Thrown_Javlin>().PopOut();
        }
    }
}
