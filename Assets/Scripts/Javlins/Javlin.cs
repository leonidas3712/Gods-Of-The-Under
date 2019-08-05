using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javlin : MonoBehaviour
{

    public float damage;
    //whether the javlin is equiped or not
    public bool javlinOn = true;

    [SerializeField]
    List<Strike> strikes = new List<Strike>();
    [SerializeField]
    List<Throw> throws = new List<Throw>();
    [SerializeField]
    List<CallBack> callBacks = new List<CallBack>();


    //called from charge and strong charge
    public void ExecuteStrike(GameObject target)
    {
        foreach (Strike s in strikes)
        {
            s.OnHit(target);
        }
    }

    // called from character controller
    public void ExecuteThrow()
    {
        if (!Character_Controller.HasThrow)
            return;
        if (Throw.thrown)
            return;
        foreach (Throw s in throws)
        {
            s.Hurl();
        }
    }
    // called from character controller
    public void ExecuteCallBack()
    {
        foreach (CallBack s in callBacks)
        {
            s.OnCallBack();
        }
    }

}
