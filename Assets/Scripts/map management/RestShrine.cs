﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestShrine : Interactable
{
    public override void ActivateInteraction()
    {
        PlayerRestCounter.playerRest.IncreaseRestCount();
        PlayerHp.playerHp.Heal(1000);
        PlayerHp.playerHp.restShrine = this;
    }
}
