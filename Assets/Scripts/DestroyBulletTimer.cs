using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletTimer : MonoBehaviour
{
    float tiempoAcumuladoEntreFrames;

    // Start is called before the first frame update
    void Start()
    {
        tiempoAcumuladoEntreFrames = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float tiempoDesdeElAnteriorFrame = Time.deltaTime; // viene en segundos (ejemplo: 0.5f es medio segundo)

        /*
         Si tu juego va a un frame rate que hace que entre cada frame pasen 0.2 segundos, 
         cuantos frames tienen que pasar para que pasen 2 segundos? 
        
            tiempo total / tiempo por frame

        1   2   3   4   5   6   7   8   9   10   | numero de frame
       0.2 0.2 0.2 0.2 0.2 0.2 0.2 0.2 0.2  0.2  | tiempo entre frames
       0.2 0.4 0.6 0.8 1.0 1.2 1.4 1.6 1.8  2.0  | tiempo acumulado


        1   2   3   4   5   6   7   8   9   10   | numero de frame
       0.2 0.1 0.3 0.4 1.0                       | tiempo entre frames
       0.2 0.3 0.6 1.0 2.0                       | tiempo acumulado
        */

        tiempoAcumuladoEntreFrames += tiempoDesdeElAnteriorFrame;

        if (tiempoAcumuladoEntreFrames >= 2.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
