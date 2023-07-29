using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeLeft = 45.0f; 
    public Text timerText; 

    private float currentTime; 
    private bool isTimerRunning = true; 
    public GameObject RespawnButton;
    public GameObject Assassino;

    private void Start()
    {
        currentTime = timeLeft;
        UpdateTimerDisplay();
        Vector3 relativePoint = transform.InverseTransformPoint(0,0,0);
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime; 
                UpdateTimerDisplay();
            }
            else
            {
                currentTime = 0f;
                isTimerRunning = false;
                timerText.text = "0:00";
                timerText.enabled = false; 
                RespawnButton.SetActive(true);
                Assassino.SetActive(false);
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}

