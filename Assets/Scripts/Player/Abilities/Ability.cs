using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    //skips sets an interval exeption(longer or shorter then regular)
    //all skips matter is to be implamented in the diriving class
    public float length, intervals, timesDone = 0, maxTimes = 1;
    float timer = 0;
    public bool AbilityOn = false;
    public string input;
    public Animator animator;

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

    public virtual bool Condition()
    {
        return Input.GetKeyDown(input);
    }

    public void DelayedAction()
    {

        if (timer < Time.time && Condition() && !AbilityOn && timesDone < maxTimes)
        {
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
