using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    private MyVector displaicement;
    [SerializeField] private MyVector position;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;

    [SerializeField] Transform target;

    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
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
}
