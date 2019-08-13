using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{

    Charge charge;
    public int damage = 2;
    private void Start()
    {
        charge = GetComponent<Charge>();
    }

    public virtual void Hit(GameObject target)
    {
        target.GetComponent<HP>().TakeDamage(damage, HelpfulFuncs.Norm1(target.transform.position - transform.position));
    }
}
