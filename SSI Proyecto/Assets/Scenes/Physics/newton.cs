using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newton : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;
    
    [SerializeField] float mass = 1;
    [SerializeField] newton mass2;

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        MyVector r = mass2.transform.position - transform.position;

        float rMagn = r.magnitude;
        MyVector force = r.normalized * (1 / mass2.mass * mass / rMagn * rMagn);
        
        acceleration *= 0f;

        ApplyForce(force);
        Move();
    }
    
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (velocity.magnitude >= 3f)
        {
            velocity.Normalize();
            velocity *= 3;
        }
        transform.position = position;
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
