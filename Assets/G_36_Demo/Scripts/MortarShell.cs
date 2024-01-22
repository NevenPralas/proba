using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShell : MonoBehaviour {

    private Rigidbody mortarRigidbody;
    public GameObject explosionPrefab;
    public GameObject explosionNoCrater;

    public GameObject teren1;
    public GameObject teren2;
    public GameObject teren3;
    public GameObject teren4;
    public GameObject teren5;

    public static int broj = 50;
    // Use this for initialization
	void Start () {
        mortarRigidbody = GetComponent<Rigidbody>();

        teren1 = GameObject.FindWithTag("Terrain");
        teren2 = GameObject.FindWithTag("TerrainF");
        teren3 = GameObject.FindWithTag("TerrainB");
        teren4 = GameObject.FindWithTag("TerrainL");
        teren5 = GameObject.FindWithTag("TerrainD");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.forward =
        Vector3.Slerp(this.transform.forward, mortarRigidbody.velocity.normalized, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        int randombroj = Random.Range(1, broj + 1);

        Debug.Log(broj);
        Debug.Log(randombroj);

        if (randombroj == 1)
        {
            Instantiate(explosionPrefab, teren1.transform.position, Quaternion.identity);

            GlobalMemory.staklo = true;

            GlobalMemory.poraz = true;
            
        }
        else
        {
            int randomBroj2 = Random.Range(1, 5);
            if(randomBroj2 == 1)
            {
                Instantiate(explosionPrefab, teren2.transform.position, Quaternion.identity);
            }
            else if(randomBroj2 == 2)
            {
                Instantiate(explosionPrefab, teren3.transform.position, Quaternion.identity);
            }
            else if(randomBroj2 == 3)
            {
                Instantiate(explosionPrefab, teren4.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(explosionPrefab, teren5.transform.position, Quaternion.identity);
            }
        }
        
        Destroy(gameObject);

    }
}
