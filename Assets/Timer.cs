using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    private bool timerStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStopped) {
            return;
        }
        float t = Time.time - startTime;
        string m = ((int) t / 60).ToString("00");
        string s = (t % 60).ToString("00");

        timerText.text = m + ":" + s;
    }

    public void TimerStop(){
        timerStopped = true; 
    }
}
