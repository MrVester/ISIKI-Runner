using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBar : MonoBehaviour
{
    public int points = 1;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            AudioController.current.PlayPickUpSound();
            collider.GetComponent<PointsSystem>().AddPoints(points);
            Destroy(gameObject);
        }
    }
}
