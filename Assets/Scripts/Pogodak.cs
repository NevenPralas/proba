using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pogodak : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Cilj"))
        {
            Debug.Log("POGODENI SMO !!!");
        }
    }
}
