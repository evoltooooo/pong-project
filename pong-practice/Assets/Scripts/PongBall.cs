using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PongBall : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction = Vector2.zero;
    float speed = 5f;
    float force = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();    
        }
        ThrowBall();
    }

    private Vector2 GenerateRandomDirection()
    {
        float randomValue = Random.Range(0f, 2f * Mathf.PI * 360f);
        return new Vector2(Mathf.Cos(randomValue), Mathf.Sin(randomValue));
    }

    void ThrowBall()
    {
        rb.AddForce(GenerateRandomDirection() * speed * force);
    }
}
