using Unity.VisualScripting;
using UnityEngine;

public class VolanOkretanje : MonoBehaviour
{
    public float brzinaRotacije = 30f;
    public float brzinaPovratka = 50f;
    public float maksimalniUgao = 60f;

    private bool rotacijaLijevo = false;
    private bool rotacijaDesno = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rotacijaLijevo = true;
            rotacijaDesno = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rotacijaLijevo = false;
            rotacijaDesno = true;
        }
        else
        {
            rotacijaLijevo = false;
            rotacijaDesno = false;
        }

        if (rotacijaLijevo)
        {
            RotirajVolan(1);
        }
        else if (rotacijaDesno)
        {
            RotirajVolan(-1);
        }
        else
        {
            VratiNaSredinu();
        }
    }

    void RotirajVolan(int smjer)
    {
        float novaRotacija = transform.eulerAngles.z + smjer * brzinaRotacije * Time.deltaTime;

        if (novaRotacija > 180)
        {
            novaRotacija -= 360;
        }

        novaRotacija = Mathf.Clamp(novaRotacija, 0f, maksimalniUgao);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, novaRotacija);
    }

    void VratiNaSredinu()
    {
        float trenutnaRotacija = transform.eulerAngles.z;


        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.MoveTowards(trenutnaRotacija, 30f, brzinaPovratka * Time.deltaTime));


    }
}

