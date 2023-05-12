using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public float speed = 0.5f;

    void FixedUpdate()
    {
        transform.Translate(0, 0, -1 * speed);
    }
}
