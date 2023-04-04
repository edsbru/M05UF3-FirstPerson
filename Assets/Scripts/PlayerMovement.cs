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
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();

        // Miramos que tanto se ha movido el mouse
        // haciendo la resta entre la posicion del frame anterior y la posicion en este frame
        Vector3 movimientoMouse = new Vector2(Input.GetAxis("Mouse X") * camSensitivity, Input.GetAxis("Mouse Y")* camSensitivity);// Input.mousePosition - lastFrameMousePosition;

        // Giramos en el eje vertical el player en funci�n del movimiento del mouse
        transform.RotateAround(transform.position, transform.up, movimientoMouse.x);
        // giramos la camara en el eje horizontal en funci�n del movimiento del mouse 
        
        Camera.main.transform.RotateAround(transform.position, transform.right, -movimientoMouse.y);
        

    }

    void Jump()
    {
        //si se detecta pulsacion del espacio
        if (Grounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        //a�adir una peque�a fuerza al eje y    
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
        // (newX, 0, newZ)  +         (0, oldY, 0)          = (newX, oldY, newZ)  
        rb.velocity = direction * speed + (Vector3.up * rb.velocity.y);
        // | 
        // '---> (0,1,0) * oldY = (0,oldY,0)
    }
}
