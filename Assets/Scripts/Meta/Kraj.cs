using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Kraj : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button returnToMainMenuButton;
    public Canvas canvasGroup;

    private void Start()
    {
        canvasGroup.enabled = false;
        GlobalMemory.pobjeda = false;
        GlobalMemory.poraz = false;

        GlobalMemory.cekanje = false;
    GlobalMemory.staklo = false;
}

    private void OnEnable()
    {
        canvasGroup.enabled = false;
        GlobalMemory.pobjeda = false;
        GlobalMemory.poraz = false;

        GlobalMemory.cekanje = false;
        GlobalMemory.staklo = false;
    }


    void Update()
    {
        // Provjeri poraz
        if (GlobalMemory.poraz)
        {
            Debug.Log("Usao");
            ShowMessage("PORAZ", Color.red);
          //  Time.timeScale = 0f; // Zaustavi igru
            ShowReturnToMainMenuButton();
        }

        // Provjeri pobjedu
        if (GlobalMemory.pobjeda)
        {
            Debug.Log("Usao");
            ShowMessage("POBJEDA", Color.green);
           // Time.timeScale = 0f; // Zaustavi igru
            ShowReturnToMainMenuButton();
        }
    }

    void ShowMessage(string message, Color color)
    {
        messageText.text = message;
        messageText.color = color;
        messageText.fontSize = 200;
        messageText.alignment = TextAlignmentOptions.Center;
        messageText.rectTransform.sizeDelta = new Vector2(1000, 1000);
        messageText.overflowMode = TextOverflowModes.Overflow;
        messageText.gameObject.SetActive(true);
    }

    void ShowReturnToMainMenuButton()
    {
        canvasGroup.enabled = true;
        // returnToMainMenuButton.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100);

        // returnToMainMenuButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -250);
        returnToMainMenuButton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 50;
       // returnToMainMenuButton.interactable = true;
       // returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Pusti igru
        SceneManager.LoadScene("MainMenu"); // Zamijenite "MainMenu" s imenom va�e scene glavnog izbornika
    }
}