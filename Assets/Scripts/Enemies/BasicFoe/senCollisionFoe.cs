using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senCollisionFoe : MonoBehaviour
{
    BasicFoe_Attack attack;
    private void Start()
    {
        attack = transform.parent.GetComponent<BasicFoe_Attack>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        attack.hitBoxCall(collision);
    }
}
