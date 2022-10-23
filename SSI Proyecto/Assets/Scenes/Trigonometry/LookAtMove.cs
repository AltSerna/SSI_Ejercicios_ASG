using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 velocity;
    private Vector2 acceleration;
    
    void Update()
    {
        Vector2 worldMousePos = GetWorldMousePos();
        Vector2 thisPos = transform.position;
        acceleration = worldMousePos - thisPos;
        velocity += acceleration * Time.deltaTime;
        LookAt(thisPos + velocity);
        Vector3 finalPosition = new Vector3(velocity.x, velocity.y, 0);
        transform.position += finalPosition * Time.deltaTime;
    }

    private void LookAt(Vector2 targetPosition)
    {
        Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 forward = targetPosition - thisPos;
        float radians = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / 2;
        RotationToZ(radians);
    }

    private Vector4 GetWorldMousePos()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotationToZ(float rad)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rad * Mathf.Rad2Deg);
    }
}
