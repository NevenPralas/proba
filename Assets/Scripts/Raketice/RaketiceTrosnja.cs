using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaketiceTrosnja : MonoBehaviour
{
    private float lastSpacePressTime;
    private float lastRPressTime;
    private bool spaceEnabled = true;

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

                if (GlobalMemory.brojRaketa != 3)
                {
                    GlobalMemory.brojRaketa = 3;
                }

                lastRPressTime = currentTime;
                spaceEnabled = false;
                Invoke("EnableSpace", 3.0f);
            }
        }
    }

    void EnableSpace()
    {
        spaceEnabled = true;
    }
}
