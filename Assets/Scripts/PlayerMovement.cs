using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpForce;

    public Transform groundedRaycastBegin;
    public Transform groundedRaycastEnd;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
    }

    void Jump()
    {
        //si se detecta pulsacion del espacio
        if (Grounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        //añadir una pequeña fuerza al eje y    
    }

    bool Grounded()
    {
        bool raycastResult = Physics.Raycast(
            groundedRaycastBegin.position,
            Vector3.down,
            Vector3.Distance(
                groundedRaycastBegin.position,
                groundedRaycastEnd.position
                ),
            LayerMask.GetMask("Floor")
            );

        return raycastResult;

    }

    void HorizontalMovement()
    {
        // primero creamos la direccion
        Vector3 direction = new Vector3(0, 0, 0);

        // los ifs lo modifican
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        // aplicamos la direccion y el speed al rb
        // (newX, 0, newZ)  +         (0, oldY, 0)          = (newX, oldY, newZ)  
        rb.velocity = direction * speed + (Vector3.up * rb.velocity.y);
        // | 
        // '---> (0,1,0) * oldY = (0,oldY,0)
    }
}
