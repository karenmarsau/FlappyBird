using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour{
    Rigidbody2D rb;

    public float leftlimit = 0.3f;
    public float rightlimit = 0.3f;
    public float speed;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 400;
    }

    void Update(){
        swingMove();
    }

    void swingMove(){
        if(transform.rotation.z < rightlimit && rb.angularVelocity > 0 && rb.angularVelocity < speed){
            rb.angularVelocity = speed;
        }else if(transform.rotation.z > leftlimit && rb.angularVelocity < 0 && rb.angularVelocity > -speed){
            rb.angularVelocity = -speed;
        }
    }
}
