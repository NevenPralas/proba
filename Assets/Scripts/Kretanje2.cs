using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kretanje2 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float ubrzanje = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        // Koristi samo W i S za kretanje po osi Y
        Vector3 targetVelocity = new Vector3(0f, rb.velocity.y, verticalInput * movementSpeed);

        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, ubrzanje * Time.deltaTime);
    }
}