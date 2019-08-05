using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendCollisionShieldFoe : MonoBehaviour
{
    ShieldFoe attack;
    private void Start()
    {
        attack = transform.parent.GetComponent<ShieldFoe>();
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        attack.hitBoxCall(collision);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack.hitBoxCall(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        attack.hitBoxCall(collision);
    }
}
