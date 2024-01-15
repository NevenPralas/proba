using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaketicePojavaNestanak : MonoBehaviour
{
    List<GameObject> childrenList = new List<GameObject>();


    void Start()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            childrenList.Add(child.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
       if (GlobalMemory.brojRaketa == 1)
        {
            childrenList[0].GetComponent<MeshRenderer>().enabled = true;
            childrenList[1].GetComponent<TextMeshPro>().text = "";
        }
        else if (GlobalMemory.brojRaketa == 0 && GlobalMemory.cekanje == false)
        {
            childrenList[0].GetComponent<MeshRenderer>().enabled = false;
            childrenList[1].GetComponent<TextMeshPro>().text = "R";
        }
    }
}

