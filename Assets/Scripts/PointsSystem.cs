using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public static PointsSystem current;
    void Awake()
    {
        current = this;
    }
    private int points = 0;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro.text = "0";
    }
    public void SetPoints(int points)
    {
        this.points = points;
    }
    public int GetPoints()
    {
        return this.points;
    }
    public void AddPoints(int points)
    {
        this.points += points;
        DisplayPoints();
    }
    public void DisplayPoints()
    {
        textMeshPro.text = points.ToString();
    }
}
