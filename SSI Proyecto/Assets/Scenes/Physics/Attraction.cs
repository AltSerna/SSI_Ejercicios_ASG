using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;

    [SerializeField] Transform target;
    [SerializeField] float mass1 = 1;
    [SerializeField] float mass2 = 1;

    [SerializeField] float gravMagn = -9.8f;

    void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        MyVector r = target.position - transform.position;

        float rMagn = r.magnitude;
        MyVector force = r.normalized * (1 / mass1 * mass2 / rMagn * rMagn);

        float weightMagn = mass2 * gravMagn;
        MyVector weight = new MyVector(0, weightMagn);

        acceleration *= 0f;

        ApplyForce(force);

        Move();
    }

    void Update()
    {
        acceleration = target.position - transform.position;
    }
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        transform.position = position;
    }
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass2);
    }
}
