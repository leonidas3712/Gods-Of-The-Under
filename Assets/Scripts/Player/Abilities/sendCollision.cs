using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendCollision : MonoBehaviour
{
    Charge charge;

    private void Start()
    {
        charge = transform.parent.GetComponent<Charge>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        charge.hitBoxCall(collision);
    }
}
