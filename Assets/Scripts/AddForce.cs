using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float speed = 0.1f;

    void Update()
    {
        transform.Translate(0, 0, -1 * speed);
    }
}
