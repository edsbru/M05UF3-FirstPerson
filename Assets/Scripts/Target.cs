using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int colorIndex;

    [HideInInspector]
    public Color targetColor;

    Rigidbody rb;

    float speed = 10.0f;
    float timeBetweenDirectionChanges = 1f;
    float timeCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetColor = TargetManager.colors[colorIndex];
        Vector3 direction = new Vector3(Random.Range(-1f,1f),0f, Random.Range(-1f, 1f));
        direction.Normalize();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if(timeCounter > timeBetweenDirectionChanges)
        {
            timeCounter = 0f;
            targetColor = TargetManager.colors[colorIndex];
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            direction.Normalize();
            rb.velocity = direction * speed;

        }

    }
}
