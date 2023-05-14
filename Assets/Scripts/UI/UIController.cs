using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public float timeToResume = 2;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject Controls;
    [SerializeField]
    private GameObject DeathScreen;
    [SerializeField]
    private TMP_Text resumeText;
    [SerializeField]
    private Image resumeImage;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Controls.SetActive(true);
        DeathScreen.SetActive(false);
        UIEvents.current.onGameStop += StopGame;
        UIEvents.current.onGameStart += StartGame;
        //CharacterEvents.current.onDeath += Dead;
        resumeImage.fillAmount = 0f;
        resumeImage.type = Image.Type.Filled;
        resumeImage.fillMethod = Image.FillMethod.Radial360;
        resumeImage.fillOrigin = 2;
        resumeText.text = "";
    }

    private void Dead()
    {
        pauseMenu.SetActive(false);
        Controls.GetComponent<Canvas>().enabled = false;
        DeathScreen.SetActive(true);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Controls.GetComponent<Canvas>().enabled = false;
        pauseMenu.SetActive(true);


    }
    private void StartGame()
    {
        pauseMenu.SetActive(false);
        resumeImage.gameObject.SetActive(true);
        StartCoroutine(ResumeGame());

    }

    IEnumerator ResumeGame()
    {
        float localTimeToResume = Time.unscaledTime + timeToResume;
        resumeImage.fillAmount = 1f;
        while (Time.unscaledTime <= localTimeToResume)
        {
            resumeImage.fillAmount -= 1.0f / timeToResume * Time.unscaledDeltaTime;
            resumeText.text = ((int)(localTimeToResume - Time.unscaledTime) + 1).ToString();

            yield return null;
        }
        resumeImage.fillAmount = 1.0f;
        resumeImage.gameObject.SetActive(false);
        Controls.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
        UIEvents.current.PlayStart();
    }

}

