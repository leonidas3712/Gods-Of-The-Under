using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    int lifeStack = -1;
    PlayerHp hp;
    public static Heal playerHeal;
    private void Start()
    {
        hp = GetComponent<PlayerHp>();
        playerHeal = this;
    }
    void Update()
    {
        if (Gravity.grounded) lifeStack = 0;
        if (Input.GetKeyDown("e")&&lifeStack>0)
        {
            hp.Heal(lifeStack);
            lifeStack = -1;
        }
    }
    public void IncreaseStack(int amount)
    {
        lifeStack += amount;
    }
}
