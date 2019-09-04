using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestShrine : Interactable
{
    public override void ActivateInteraction()
    {
        PlayerRestCounter.playerRest.IncreaseRestCount();
    }
}
