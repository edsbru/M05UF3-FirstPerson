using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        score.text= "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
