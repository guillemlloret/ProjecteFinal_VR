using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // text mesh pro

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [SerializeField] TextMeshProUGUI timeTextBox;


    void Start()
    {
        //timeTextBox = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTimer();
    }

    private void UpdateGameTimer()
    {
        gameTime -= Time.deltaTime;
        var minutes = Mathf.FloorToInt(gameTime / 60);
        var seconds = Mathf.FloorToInt(gameTime - minutes * 60);



        string gameTimeClockDisplay = string.Format("{0:0}:{1:0}", minutes, seconds);
        
        timeTextBox.text = gameTimeClockDisplay;
    }

}
