using UnityEngine;
using UnityEngine.SceneManagement;

public class Kraj2 : MonoBehaviour
{
    

    void Update()
    {
        if (GlobalMemory.pobjeda || GlobalMemory.poraz)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}