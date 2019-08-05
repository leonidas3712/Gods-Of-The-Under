using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedAction : MonoBehaviour {

    //skips sets an interval exeption(longer or shorter then regular)
    //all skips matter is to be implamented in the diriving class
    public float length, intervals, timesDone = 0, maxTimes = 1;
    float timer = 0;
    public bool AbilityOn = false,condition;

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
    }


    public void DelayedAction()
    {
        if (timer < Time.time && condition && !AbilityOn && timesDone < maxTimes)
        {
            condition = false;
            AbilityOn = true;
            Action();
            timer = Time.time + length;
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
