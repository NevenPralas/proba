using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 5f; 
    private Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartMovement();
        }

        if (isMoving)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meta"))
        {
            StopMovement();
            Debug.Log("Objekt je sudario s drugim objektom!");
        }
    }

    void StartMovement()
    {
        isMoving = true;
    }

    void StopMovement()
    {
        isMoving = false;
        rb.velocity = Vector3.zero;
    }
}
