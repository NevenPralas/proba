using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject soldierPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meta"))
        {
            InstantiateExplosion(collision.contacts[0].point);

            Destroy(collision.gameObject);
        }
    }

    void InstantiateExplosion(Vector3 position)
    {
        GameObject explosion1 = Instantiate(explosionPrefab, position, Quaternion.identity);
        GameObject explosion2 = Instantiate(explosionPrefab, position, Quaternion.identity);
        GameObject explosion3 = Instantiate(explosionPrefab, position, Quaternion.identity);
        GameObject explosion4 = Instantiate(explosionPrefab, position, Quaternion.identity);
        GameObject explosion5 = Instantiate(explosionPrefab, position, Quaternion.identity);

        GameObject soldier1 = Instantiate(soldierPrefab, position, Quaternion.identity);
        GameObject soldier2 = Instantiate(soldierPrefab, position, Quaternion.identity);

        explosion2.transform.Translate(Vector3.left * 3f);
        explosion3.transform.Translate(Vector3.right * 3f);
        explosion4.transform.Translate(Vector3.forward * 3f);
        explosion5.transform.Translate(Vector3.back * 3f);

        explosion1.transform.Translate(Vector3.down * 1f);
        explosion2.transform.Translate(Vector3.down * 1f);
        explosion3.transform.Translate(Vector3.down * 1f);
        explosion4.transform.Translate(Vector3.down * 1f);
        explosion5.transform.Translate(Vector3.down * 1f);

        soldier1.transform.Rotate(90f, 0f, 0f);
        soldier2.transform.Rotate(90f, 0f, 0f);
        soldier2.transform.Translate(Vector3.left * 3f);
    }
}
