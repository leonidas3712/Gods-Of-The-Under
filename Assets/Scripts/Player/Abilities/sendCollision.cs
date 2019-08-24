using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendCollision : MonoBehaviour
{
    Charge charge;
    float timer;
    private void OnEnable()
    {
        timer = Time.time + 0.03f;
        transform.tag = "hitBox";
    }
    private void Awake()
    {
        charge = transform.parent.GetComponent<Charge>();
    }
    private void Update()
    {
        if (timer <= Time.time)
        {
            transform.tag = "Player";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        charge.hitBoxCall(collision,timer>Time.time);
    }
}
