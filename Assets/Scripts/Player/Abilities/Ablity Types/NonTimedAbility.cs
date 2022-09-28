using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonTimedAbility : Ability
{
    public override void Update()
    {
        if (AbilityOn)
        {
            WhileIsOn();
            timeLeft = timer - Time.time;
        }
    }
}
