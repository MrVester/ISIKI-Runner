using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    Button restartButton;
    void Start()
    {
        restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
    }
}
