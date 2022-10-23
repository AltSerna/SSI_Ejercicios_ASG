using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVelocity : MonoBehaviour
{
    private MyVector displaicement;
    [SerializeField] private MyVector position;    
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector acceleration;

    int state;
    [SerializeField] float gravMagni = 9.8f;
    MyVector[] directions = new MyVector[4]
    {
        new MyVector(0,1),
        new MyVector(1,0),
        new MyVector(0,-1),
        new MyVector(-1,0)
    };
    

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = (state + 1) % 4;
            velocity = velocity * 0;
            acceleration = directions[state] * gravMagni;
        }
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
}
