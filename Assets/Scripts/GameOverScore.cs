using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<TextMeshProUGUI>().text = ScoreManager.scoretext;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
