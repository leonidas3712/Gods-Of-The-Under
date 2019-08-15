using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour {

    GameObject javlin;
    Rigidbody2D rig;
    [SerializeField]
    public float returnSpeed = 15;
    public static CallBack call;
    private void Start()
    {
        call = this;
    }
    public virtual void ExecuteCallBack()
    {
        
        javlin = GameObject.FindGameObjectWithTag("javlin");
        if (!javlin)
            return;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), javlin.GetComponent<Collider2D>(),false);
        rig = javlin.GetComponent<Rigidbody2D>();
        javlin.GetComponent<Thrown_Javlin>().returning = true;
        javlin.GetComponent<Thrown_Javlin>().flying = false;
        javlin.layer = 0;
        foreach (Collider2D coll in javlin.GetComponents<Collider2D>())
        {
            coll.isTrigger = true;
        }
        rig.gravityScale = 0;
        rig.bodyType = RigidbodyType2D.Dynamic;
    }
}
