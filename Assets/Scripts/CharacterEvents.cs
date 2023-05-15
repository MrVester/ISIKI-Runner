using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public static CharacterEvents current;
    void Awake()
    {
        current = this;
    }

    public event Action onDeath;
    public void Death()
    {
        if (onDeath != null)
            onDeath();
    }
}
