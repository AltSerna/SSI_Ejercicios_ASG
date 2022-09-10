using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;

    [SerializeField] float mass = 1;
    [SerializeField] MyVector windVectForce;
    
    [SerializeField] MyVector gravVectForce = new MyVector(0, -9.8f);

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        acceleration *= 0f;
        ApplyForce(windVectForce);
        ApplyForce(gravVectForce);
        Move();
    }

    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
        }

        transform.position = position;
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
