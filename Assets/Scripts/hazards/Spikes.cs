using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject victem = coll.collider.gameObject;
        if (victem.GetComponent<HP>())
        {
            victem.GetComponent<HP>().TakeDamage(1,HelpfulFuncs.Norm1(coll.GetContact(0).point-(Vector2)victem.transform.position));
        }
        if (victem.GetComponent<PlayerHp>())
        {
            victem.GetComponent<PlayerHp>().TakeDamage(1, HelpfulFuncs.Norm1(coll.GetContact(0).point - (Vector2)victem.transform.position),true);
        }
        else if (victem.tag == "javlin")
        {
            victem.GetComponent<Thrown_Javlin>().popOut();
        }
    }
}
