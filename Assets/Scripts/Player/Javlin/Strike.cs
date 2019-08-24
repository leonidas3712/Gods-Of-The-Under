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
        HP hp = target.GetComponent<HP>();
        if (!hp)
            hp = target.GetComponentInParent<HP>();
        hp.TakeDamage(damage, HelpfulFuncs.Norm1(target.transform.position - transform.position));
        Heal.playerHeal.IncreaseStack(1);
    }
}
