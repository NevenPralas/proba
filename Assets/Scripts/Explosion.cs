using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject soldierPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meta"))
        {
            InstantiateExplosion(other.ClosestPointOnBounds(transform.position));

            Destroy(other.gameObject);
            StartCoroutine(Pobjeda());
            
        }
        else if (other.gameObject.CompareTag("OstaliObjekti"))
        {
            InstantiateExplosion2(other.ClosestPointOnBounds(transform.position));
        }
    }

    IEnumerator Pobjeda()
    {
        yield return new WaitForSeconds(5f);
        GlobalMemory.pobjeda = true;
    }



    void InstantiateExplosion(Vector3 position)
    {
        GameObject explosion1 = Instantiate(explosionPrefab, position, Quaternion.identity);

        GameObject soldier1 = Instantiate(soldierPrefab, position, Quaternion.identity);
        GameObject soldier2 = Instantiate(soldierPrefab, position, Quaternion.identity);


        explosion1.transform.Translate(Vector3.down * 1f);

        soldier1.transform.Rotate(90f, 0f, 0f);
        soldier2.transform.Rotate(90f, 0f, 0f);
        soldier2.transform.Translate(Vector3.left * 3f);
    }

    void InstantiateExplosion2(Vector3 position)
    {
        GameObject explosion1 = Instantiate(explosionPrefab, position, Quaternion.identity);



     //   explosion1.transform.Translate(Vector3.down * 1f);

    }
}
