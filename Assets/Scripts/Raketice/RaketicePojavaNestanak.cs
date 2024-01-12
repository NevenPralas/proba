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
        if (GlobalMemory.brojRaketa == 3)
        {
            if (childrenList[0].GetComponent<MeshRenderer>().enabled == false && childrenList[1].GetComponent<MeshRenderer>().enabled == false &&
                childrenList[2].GetComponent<MeshRenderer>().enabled == false)
            {
                StartCoroutine(Pricekaj1(childrenList[0], childrenList[1], childrenList[2]));
            }
            else if (childrenList[0].GetComponent<MeshRenderer>().enabled == false && childrenList[1].GetComponent<MeshRenderer>().enabled == false &&
                childrenList[2].GetComponent<MeshRenderer>().enabled == true)
            {
                StartCoroutine(Pricekaj2(childrenList[0], childrenList[1]));
            }
            else if (childrenList[0].GetComponent<MeshRenderer>().enabled == false && childrenList[1].GetComponent<MeshRenderer>().enabled == true &&
                childrenList[2].GetComponent<MeshRenderer>().enabled == true)
            {
                StartCoroutine(Pricekaj3(childrenList[0]));
            }

            childrenList[3].GetComponent<TextMeshPro>().text = "";
        }
        else if (GlobalMemory.brojRaketa == 2)
        {
            childrenList[0].GetComponent<MeshRenderer>().enabled = false;
            childrenList[1].GetComponent<MeshRenderer>().enabled = true;
            childrenList[2].GetComponent<MeshRenderer>().enabled = true;
            childrenList[3].GetComponent<TextMeshPro>().text = "";
        }
        else if (GlobalMemory.brojRaketa == 1)
        {
            childrenList[0].GetComponent<MeshRenderer>().enabled = false;
            childrenList[1].GetComponent<MeshRenderer>().enabled = false;
            childrenList[2].GetComponent<MeshRenderer>().enabled = true;
            childrenList[3].GetComponent<TextMeshPro>().text = "";
        }
        else if (GlobalMemory.brojRaketa == 0)
        {
            childrenList[0].GetComponent<MeshRenderer>().enabled = false;
            childrenList[1].GetComponent<MeshRenderer>().enabled = false;
            childrenList[2].GetComponent<MeshRenderer>().enabled = false;
            childrenList[3].GetComponent<TextMeshPro>().text = "R";
        }
    }

    IEnumerator Pricekaj1(GameObject gameObject1, GameObject gameObject2, GameObject gameObject3)
    {
        yield return new WaitForSeconds(1f);
        gameObject3.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        gameObject2.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        gameObject1.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator Pricekaj2(GameObject gameObject1, GameObject gameObject2)
    {
        yield return new WaitForSeconds(1f);
        gameObject2.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        gameObject1.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator Pricekaj3(GameObject gameObject1)
    {
        yield return new WaitForSeconds(1f);
        gameObject1.GetComponent<MeshRenderer>().enabled = true;
    }
}

