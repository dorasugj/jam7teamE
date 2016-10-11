using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerLabel;
    public bool isStop = true;
    public bool isFinish = false;
    public bool isGameOver = false;

    float timer = 10;

    void Start()
    {
    }

    void Update()
    {
        if (isFinish || isGameOver || isStop) return;

        timer -= Time.deltaTime;
        timerLabel.text = "Time:" + (int)(timer);

        if (timer <= 0) TimeFinish();
    }
    void TimeFinish()
    {
        isFinish = true;
    }
}
