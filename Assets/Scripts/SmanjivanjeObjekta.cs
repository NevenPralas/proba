using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmanjivanjeObjekta : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PostupnoSmanjenje());
    }

    IEnumerator PostupnoSmanjenje()
    {
        while (transform.localScale.x > 0.2f)
        {
            transform.localScale -= new Vector3(0.02f, 0, 0.02f);

            yield return new WaitForSeconds(1f);
        }

    }
}
