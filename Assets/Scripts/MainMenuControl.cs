using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;

public class MainMenuControl : MonoBehaviour
{


    [Header("Settings")]
    public GameObject settingsTab;
    public Button backButtonFromSettings;
    [Header("MainMenu")]
    public GameObject mainMenuTab;
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;




    void Start()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));

        settingsButton.onClick.AddListener(() => SettingsButtonEvent());
        quitButton.onClick.AddListener(() => Application.Quit());

        backButtonFromSettings.onClick.AddListener(() => BackButtonFromSettingsEvent());
    }


    void Update()
    {

    }

    private void BackButtonFromSettingsEvent()
    {
        settingsTab.SetActive(false);
        mainMenuTab.SetActive(true);
    }
    private void SettingsButtonEvent()
    {
        settingsTab.SetActive(true);
        mainMenuTab.SetActive(false);
    }


}
