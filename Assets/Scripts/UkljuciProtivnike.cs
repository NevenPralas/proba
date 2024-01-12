using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkljuciProtivnike : MonoBehaviour
{
    public GameObject protivnici;

    public void ukljuciProtivnike()
    {
        protivnici.SetActive(true);
    }
}

