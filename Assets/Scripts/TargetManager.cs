using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public Image srCurrentTarget;
    public Image srNextTarget;

    public static Color currentColor;

    public static TargetManager instance;

    public static Color[] colors = { Color.red, Color.blue, Color.green };
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        srCurrentTarget.color = colors[Random.Range(0, 3)];
        srNextTarget.color = colors[Random.Range(0, 3)];
        currentColor = srCurrentTarget.color;
    }

    // Update is called once per frame
    public void OnTargetHit()
    {
            srCurrentTarget.color = srNextTarget.color;
            srNextTarget.color = colors[Random.Range(0,3)];
            currentColor = srCurrentTarget.color;
    }
}
