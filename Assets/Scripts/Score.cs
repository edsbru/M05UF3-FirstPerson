using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public static int scoreValue;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        //score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue.ToString();
    }
}//Score.scoreValue += puntos
