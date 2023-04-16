using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float camSensitivity;

    public Transform groundedRaycastBegin;
    public Transform groundedRaycastEnd;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    float verticalRotation = 0f;
    float horizontalRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();

        // Miramos que tanto se ha movido el mouse
        // haciendo la resta entre la posicion del frame anterior y la posicion en este frame
        Vector2 movimientoMouse = new Vector2(
            // movimiento del mouse en X
            Input.GetAxis("Mouse X") * camSensitivity,
            // movimiento del mouse en Y
            Input.GetAxis("Mouse Y") * camSensitivity
        );

        // Giramos en el eje vertical el player en función del movimiento del mouse
        verticalRotation += movimientoMouse.x;
        
        // Giramos la camara en el eje horizontal en función del movimiento del mouse 
        horizontalRotation+= movimientoMouse.y;

        //aplicamos rotacion
        transform.rotation = Quaternion.Euler(new Vector3(-horizontalRotation ,verticalRotation, 0));

        float diferenciaAngularForward = Vector3.Angle(transform.forward, Camera.main.transform.forward);

        if(diferenciaAngularForward >= 85f)
        {
            horizontalRotation -= movimientoMouse.y;
            // Invertimos la rotacion
            transform.rotation = Quaternion.Euler(new Vector3(-horizontalRotation, verticalRotation, 0));

        }

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
            direction += transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction -= transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right;
        }

        // aplicamos la direccion y el speed al rb
        Vector3 nuevaVelocidad = direction * speed;
        // para conservar la velocidad vertical:
        nuevaVelocidad.y = rb.velocity.y;
        
        rb.velocity = nuevaVelocidad;


    }
}
