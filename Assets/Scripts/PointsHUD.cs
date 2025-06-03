using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PointsHUD : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;

    int points = 0;

    private void Awake()
    {
        UpdateHUD();
    }
    public int Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
            UpdateHUD();
        }
    }

    private void UpdateHUD()
    {
        pointsText.text = points.ToString();
    }
}
