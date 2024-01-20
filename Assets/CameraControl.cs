using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float brzinaRotacije = 5.0f;
    public float maksimalnaRotacijaX = 15f;
    public float minimalnaRotacijaX = -15f;
    public float maksimalnaRotacijaY = 15f;
    public float minimalnaRotacijaY = -15f;

    private float trenutnaRotacijaX = 0f;
    private float trenutnaRotacijaY = 0f;

    void Update()
    {
        float unosVerticalnoKamere = 0;
        float unosHorizontalnoKamere = 0;

        if (Input.GetKey(KeyCode.S))
            unosVerticalnoKamere = 1;
        else if (Input.GetKey(KeyCode.W))
            unosVerticalnoKamere = -1;

        if (Input.GetKey(KeyCode.A))
            unosHorizontalnoKamere = -1;
        else if (Input.GetKey(KeyCode.D))
            unosHorizontalnoKamere = 1;

        Vector3 rotacijaKamere = new Vector3(unosVerticalnoKamere, unosHorizontalnoKamere, 0) * brzinaRotacije * Time.deltaTime;

        // Prati trenutnu rotaciju
        trenutnaRotacijaX += rotacijaKamere.x;
        trenutnaRotacijaY += rotacijaKamere.y;

        // Linearna interpolacija izmeðu minimalne i maksimalne rotacije
        trenutnaRotacijaX = Mathf.Lerp(trenutnaRotacijaX, Mathf.Clamp(trenutnaRotacijaX, minimalnaRotacijaX, maksimalnaRotacijaX), Time.deltaTime * 2f);
        trenutnaRotacijaY = Mathf.Lerp(trenutnaRotacijaY, Mathf.Clamp(trenutnaRotacijaY, minimalnaRotacijaY, maksimalnaRotacijaY), Time.deltaTime * 2f);

        // Rotiraj kameru oko svojih lokalnih osi
        transform.localRotation = Quaternion.Euler(trenutnaRotacijaX, trenutnaRotacijaY, 0);

    }
}
