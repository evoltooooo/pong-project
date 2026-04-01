using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementVector;
    float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector2(0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        rb.transform.position += (Vector3) movementVector * speed * Time.fixedDeltaTime;
    }
}
