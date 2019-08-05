using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeAbility : MonoBehaviour {

    //skips sets an interval exeption(longer or shorter then regular)
    //all skips matter is to be implamented in the diriving class
    public float length, intervals, timesDone = 0, maxTimes = 1;
    float timer = 0;
    public bool AbilityOn = false,Cond;
    protected Rigidbody2D rig;



    public virtual void Action() { }
    public virtual void Finish() { }
    public virtual void WhileIsOn() { }

    public void ResetTimesDone()
    {
        timesDone = 0;
    }
    public void ForceEnding()
    {
        timer = 0;
        timer = Time.time + intervals;
        AbilityOn = false;
        Finish();
    }


    public void DelayedAction()
    {
        if (timer < Time.time && Cond && !AbilityOn && timesDone < maxTimes)
        {
            AbilityOn = true;
            Action();
            timer = Time.time + length;
            Cond = false;
        }
        else
         if (timer <= Time.time && AbilityOn == true)
        {
            timer = Time.time + intervals;
            AbilityOn = false;
            Finish();
        }
        if (AbilityOn)
            WhileIsOn();

    }


    /*
     *for deriving classes
     * public override void Action()
     {

     }
     public override void Finish()
     {

     }
     public override void WhileIsOn()
     {

     }*/
}
