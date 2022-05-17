using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public InputAction playerControls;
    Vector2 moveDirection = Vector2.zero;
    Vector3 direction = Vector3.zero;
    public float topSpeed = 1000f;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        direction.x = moveDirection.x;
        direction.z = moveDirection.y;
        Vector3 localDirection = transform.TransformDirection(direction);
        //rb.MovePosition(rb.position + (localDirection * moveSpeed * Time.deltaTime));
        rb.AddForce(new Vector3(direction.x, 0, direction.z) * moveSpeed * Time.deltaTime);
        Vector2 currentSpeed = new Vector2(rb.velocity.x, rb.velocity.z);
        if (currentSpeed.magnitude > topSpeed)
        {
            currentSpeed = currentSpeed.normalized * topSpeed;
            rb.velocity = new Vector3(currentSpeed.x, 1, currentSpeed.y);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Collect pick ups
        if (other.CompareTag("Pick Up"))
        {
            Debug.Log("Pick up collected!");
            GameObject.Destroy(other.gameObject);
        }

    }
}


//playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);