using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Kraj : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button returnToMainMenuButton;

    void Update()
    {
        // Provjeri poraz
        if (GlobalMemory.poraz)
        {
            Debug.Log("Usao");
            ShowMessage("PORAZ", Color.red);
            Time.timeScale = 0f; // Zaustavi igru
            ShowReturnToMainMenuButton();
        }

        // Provjeri pobjedu
        if (GlobalMemory.pobjeda)
        {
            Debug.Log("Usao");
            ShowMessage("POBJEDA", Color.green);
            Time.timeScale = 0f; // Zaustavi igru
            ShowReturnToMainMenuButton();
        }
    }

    void ShowMessage(string message, Color color)
    {
        messageText.text = message;
        messageText.color = color;
        messageText.gameObject.SetActive(true);
    }

    void ShowReturnToMainMenuButton()
    {
        returnToMainMenuButton.gameObject.SetActive(true);
        returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Pusti igru
        SceneManager.LoadScene("MainMenu"); // Zamijenite "MainMenu" s imenom vaše scene glavnog izbornika
    }
}
