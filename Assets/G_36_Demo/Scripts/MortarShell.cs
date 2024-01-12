using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShell : MonoBehaviour
{

    private Rigidbody mortarRigidbody;
    public GameObject explosionPrefab;
    public GameObject explosionNoCrater;
    // Use this for initialization
    void Start()
    {
        mortarRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.forward =
        Vector3.Slerp(this.transform.forward, mortarRigidbody.velocity.normalized, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        GameObject terrainObject1 = GameObject.FindGameObjectWithTag("Terrain");
        // Dohvati granice objekta tipa Plane
        Renderer terrainRenderer1 = terrainObject1.GetComponent<Renderer>();
        Bounds terrainBounds1 = terrainRenderer1.bounds;

        // Postavi novu poziciju za raketu unutar granica objekta tipa Plane
        float x = Random.Range(terrainBounds1.min.x, terrainBounds1.max.x);
        float y = Random.Range(terrainBounds1.min.y, terrainBounds1.max.y);
        float z = Random.Range(terrainBounds1.min.z, terrainBounds1.max.z);
        transform.position = new Vector3(
            x, y, z
        );

        if (collision.gameObject.CompareTag("Terrain"))
        {
            // Dohvati referencu na objekt tipa Plane s tagom "Terrain"
            GameObject terrainObject = GameObject.FindGameObjectWithTag("Terrain");

            if (terrainObject != null)
            {
                // Dohvati granice objekta tipa Plane
                Renderer terrainRenderer = terrainObject.GetComponent<Renderer>();
                Bounds terrainBounds = terrainRenderer.bounds;

                // Postavi novu poziciju za instanciranje eksplozije
                Vector3 randomPosition = new Vector3(x, y, z);

                // Instanciraj eksploziju na novoj poziciji
                Instantiate(explosionPrefab, randomPosition, Quaternion.identity);
            }
        }
        else
        {
            GameObject terrainObject = GameObject.FindGameObjectWithTag("Terrain");

            Renderer terrainRenderer = terrainObject.GetComponent<Renderer>();
            Bounds terrainBounds = terrainRenderer.bounds;

            // Postavi novu poziciju za instanciranje eksplozije
            Vector3 randomPosition = new Vector3(x, y, z);

            Instantiate(explosionNoCrater, randomPosition, Quaternion.identity);
        }
    }
}
