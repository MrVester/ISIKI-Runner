
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    Button _menuButton;
    void Start()
    {
        _menuButton = GetComponent<Button>();
        _menuButton.onClick.AddListener(() => MenuButtonRelease());
    }

    private void MenuButtonRelease()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
