using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float speed;

    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = bulletSpawn.transform.position;
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * speed;
        }
    }
}
