using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private bool isMoving = false;

    public TMP_Text streliceLijevo;
    public TMP_Text streliceDesno;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveInput) > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        MoveTank(moveInput);
        RotateTank(rotateInput);
    }

    void MoveTank(float moveInput)
    {
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;

        // Pomakni tenk
        transform.Translate(movement, Space.World);
    }

    void RotateTank(float rotateInput)
    {
        if (isMoving)
        {
            float rotationAngle = rotateInput * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotationAngle);

            if(rotateInput > 0)
            {
                streliceDesno.color = Color.red;
                streliceLijevo.color = Color.white;
            }
            if(rotateInput < 0)
            {
                streliceLijevo.color = Color.red;
                streliceDesno.color = Color.white;
            }
            if(rotateInput == 0)
            {
                streliceDesno.color = Color.white;
                streliceLijevo.color = Color.white;
            }
        }
        else
        {
            streliceDesno.color = Color.white;
            streliceLijevo.color = Color.white;
        }
    }
}

