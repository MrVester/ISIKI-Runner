using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    private float points = 0;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro.text = "Bars collected: 0";
    }
    public void SetPoints(int points)
    {
        this.points = points;
    }
    public void AddPoints(int points)
    {
        this.points += points;
        DisplayPoints();
    }
    public void DisplayPoints()
    {
        textMeshPro.text = "Bars collected: " + points.ToString();
    }
}
