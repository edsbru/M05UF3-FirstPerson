using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    Rigidbody rb;
    public int speed = 5;

    void Awake()
    {
        Destroy(gameObject, life);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Score.scoreValue += 10;
        }
    }
}
