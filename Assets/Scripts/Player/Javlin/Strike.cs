using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{

    Charge charge;
    private void Start()
    {
        charge = GetComponent<Charge>();
    }

    public virtual void OnHit(GameObject target)
    {
        target.GetComponent<HP>().TakeDamage(1, HelpfulFuncs.Norm1(target.transform.position - transform.position));
        if (target)
            charge.ForceEnding();
    }
}
