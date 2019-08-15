using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ability : MonoBehaviour
{
    //skips sets an interval exeption(longer or shorter then regular)
    //all skips matter is to be implamented in the diriving class
    public float length, intervals, timesDone = 0, maxTimes = 1;
    protected float timer = 0,timeLeft;
    public bool AbilityOn = false;
    public string input;
    public Animator animator;
    public bool canInterrupt = true, isInterruptable = true;

    public delegate void InterruptionEvent();
    public event InterruptionEvent triggerInterruptions;

    protected float inputTimer = 0, inputTriggerTime = 0.1f;

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

    public virtual void Interrupt()
    {
        ForceEnding();
    }

    public virtual bool Condition()
    {
        return inputTimer > Time.time;
    }

    public virtual void CheckInput()
    {
        if (Input.GetKeyDown(input)) inputTimer = Time.time + inputTriggerTime;
    }

    public virtual void TriggerAbility()
    {
        if (timer < Time.time && !AbilityOn && timesDone < maxTimes)
        {
            if (canInterrupt)
                triggerInterruptions();
            AbilityOn = true;
            Action();
            WhileIsOn();
            timer = Time.time + length;
        }
    }

    public virtual void Update()
    {
        CheckInput();
        if (timer <= Time.time && AbilityOn == true)
        {
            timer = Time.time + intervals;
            AbilityOn = false;
            Finish();
        }
        if (AbilityOn)
        {
            WhileIsOn();
            timeLeft = timer - Time.time;
        }

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
