using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;

    public float timeRemaining; 

    public static ScoreManager instance;
    public static string scoretext = "0";


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score.text= "0";
        timer.text= timeRemaining.ToString();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        int minutes = (int)(timeRemaining / 60f);
        int seconds = (int)(timeRemaining - ((float)minutes * 60));

        if (seconds < 10)
        {
            timer.text = minutes+ ":0" + seconds;

        }else
        {
            timer.text = minutes + ":" + seconds;
        }

        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene(1);    
        }
    }

    public void IncreaseScore()
    {
        score.text = ""+(int.Parse(score.text)+1);
        scoretext = score.text;
    }

    //a cada seguindo se resta 1 al valor de timeRemaining y al llegar a 0 que se frezee el tiempo

}
