using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{

    Charge charge;
    Strong_Charge strongCharge;
    private void Start()
    {
        charge = GetComponent<Charge>();
        strongCharge = GetComponent<Strong_Charge>();
    }

    public virtual void OnHit(GameObject target)
    {
        if (charge.AbilityOn)
        {
            target.GetComponent<HP>().TakeDamage(1, HelpfulFuncs.Norm1(target.transform.position - transform.position));
            if (target)
                charge.ForceEnding();
        }

        else if (strongCharge.isCharging)
        {
            target.GetComponent<HP>().TakeDamage(2, HelpfulFuncs.Norm1(target.transform.position - transform.position));
            if (target)
                strongCharge.EndCharge();
        }

    }

    /*public virtual void OnStart()
    {

    }

    public virtual void OnEnd()
    {

    }*/
}
