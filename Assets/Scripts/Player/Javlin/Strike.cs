using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{

    Charge charge;
    public int damage = 2;
    int damageStack = -1, curDamage;
    private void Start()
    {
        charge = GetComponent<Charge>();
        Gravity.playerGravity.groundCall += ResetStack;
        PlayerHp.playerHp.Damaged += ResetStack;
    }
    public virtual void ResetStack()
    {
        damageStack = -1;
    }
    public virtual void DecreaseStack()
    {
        if (damageStack > -1) damageStack--;
    }
    public virtual void Hit(GameObject target)
    {
        curDamage = damage;
        HP hp = target.GetComponent<HP>();
        if (!hp)
            hp = target.GetComponentInParent<HP>();
        if (damageStack > 0)
            curDamage += damageStack;

        hp.TakeDamage(curDamage, HelpfulFuncs.Norm1(target.transform.position - transform.position));

        if (damageStack < damage)
            damageStack++;

        Heal.playerHeal.IncreaseStack(1);
    }
}
