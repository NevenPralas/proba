using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float brzinaRotacije = 5.0f;

    void Update()
    {
        float unosVerticalnoKamere = 0;
        float unosHorizontalnoKamere = 0;

        if (Input.GetKey(KeyCode.W))
            unosVerticalnoKamere = 1;
        else if (Input.GetKey(KeyCode.S))
            unosVerticalnoKamere = -1;

        if (Input.GetKey(KeyCode.A))
            unosHorizontalnoKamere = -1;
        else if (Input.GetKey(KeyCode.D))
            unosHorizontalnoKamere = 1;

        Vector3 rotacijaKamere = new Vector3(unosVerticalnoKamere, unosHorizontalnoKamere, 0) * brzinaRotacije * Time.deltaTime;
        transform.Rotate(rotacijaKamere);


    }
}
