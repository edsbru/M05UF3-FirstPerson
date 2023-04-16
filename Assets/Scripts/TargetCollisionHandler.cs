using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //estoy aqui pero no me ejecuto hasta que colisiono
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //bala comprueva que el color del target sea el correcto (el mismo que "CurrentTarget UI")
    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.collider.gameObject.GetComponent<Target>();

        if (target != null && target.targetColor == TargetManager.currentColor)
        {
            TargetManager.instance.OnTargetHit();
            ScoreManager.instance.IncreaseScore();
        }
    }
}
