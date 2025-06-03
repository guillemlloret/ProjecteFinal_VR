using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [SerializeField] TextMeshProUGUI timeTextBox;
    public GameObject CompletedDay;

    private bool timeUp = false;
    void Update()
    {
        UpdateGameTimer();
    }

    private void UpdateGameTimer()
    {
        if (timeUp) return;

        gameTime -= Time.deltaTime;

        if (gameTime <= 0f)
        {
            gameTime = 0f;
            timeUp = true;
            CompletedDay.SetActive(true);
        }

        var minutes = Mathf.FloorToInt(gameTime / 60);
        var seconds = Mathf.FloorToInt(gameTime - minutes * 60);

        string gameTimeClockDisplay = string.Format("{0:0}:{1:0}", minutes, seconds);
        timeTextBox.text = gameTimeClockDisplay;
    }
}