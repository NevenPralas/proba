using System.Collections;
using UnityEngine;

public class SmanjivanjeObjekta : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
           Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(PostupnoSmanjenje());
        }
    }

    IEnumerator PostupnoSmanjenje()
    {
        yield return new WaitForSeconds(30f);

        while (transform.localScale.x > 0.2f)
        {
            transform.localScale -= new Vector3(0.02f, 0, 0.02f);
            yield return new WaitForSeconds(1f);
        }
    }
}
