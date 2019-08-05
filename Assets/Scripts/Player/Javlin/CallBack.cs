using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBack : MonoBehaviour {

    GameObject javlin;
    Rigidbody2D rig;
    [SerializeField]
    float returnSpeed = 15;
    public virtual void OnCallBack()
    {
        
        javlin = GameObject.FindGameObjectWithTag("javlin");
        if (!javlin)
            return;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), javlin.GetComponent<Collider2D>(),false);
        rig = javlin.GetComponent<Rigidbody2D>();
        javlin.GetComponent<Thrown_Javlin>().returning = true;
        javlin.GetComponent<Thrown_Javlin>().flying = false;
        foreach (Collider2D coll in javlin.GetComponents<Collider2D>())
        {
            coll.isTrigger = true;
        }
        rig.gravityScale = 0;
        rig.bodyType = RigidbodyType2D.Dynamic;
        rig.velocity = Vector3.Normalize(transform.position - javlin.transform.position) * returnSpeed;
    }
}
