using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RaketiceTrosnja : MonoBehaviour
{
    private float lastSpacePressTime;
    private float lastRPressTime;
    private bool spaceEnabled = true;

    public GameObject raketica;
    private Vector3 pocetnaPozicija;

    private Rigidbody rb;

    public GameObject tekstic;
    private void Start()
    {
        pocetnaPozicija = raketica.transform.localPosition;
        rb = raketica.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceEnabled)
        {
            float currentTime = Time.time;

            if (currentTime - lastSpacePressTime >= 1.0f)
            {
                Debug.Log("SPACE" + GlobalMemory.brojRaketa);

                if (GlobalMemory.brojRaketa != 0)
                {
                    GlobalMemory.brojRaketa--;
                }

                lastSpacePressTime = currentTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            float currentTime = Time.time;

            if (currentTime - lastRPressTime >= 3.0f)
            {
                Debug.Log("R" + GlobalMemory.brojRaketa);

                tekstic.GetComponent<TextMeshPro>().text = "...";

                lastRPressTime = currentTime;
                spaceEnabled = false;

                GlobalMemory.cekanje = true;

                Invoke("EnableSpace", 3.0f);
             
            }
        }
    }

    void EnableSpace()
    {
        spaceEnabled = true;

        raketica.GetComponent<Rigidbody>().velocity = Vector3.zero;
        raketica.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Debug.Log(pocetnaPozicija);
        raketica.transform.localPosition = pocetnaPozicija;

        rb.constraints = RigidbodyConstraints.FreezePosition;
        if (GlobalMemory.brojRaketa != 1)
        {
            GlobalMemory.brojRaketa = 1;
            GlobalMemory.cekanje = false;
        }
        
    }

   
}
