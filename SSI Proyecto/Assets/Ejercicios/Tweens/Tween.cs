using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    
    [SerializeField] Transform target;
    [SerializeField] float time;
    [SerializeField, Range(0, 1)] float tParameter = 0;
    [SerializeField] Color targetColor;
    [SerializeField] private AnimationCurve curve;
    Color initialColor;
    float currentTime;
    Vector3 initialPos;
    Vector3 targetPos;
    SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        initialPos = transform.position;
        targetPos = initialPos;
    }

    private void Update()
    {
        tParameter = currentTime / time;
        transform.position = Vector2.LerpUnclamped(initialPos, targetPos, curve.Evaluate(tParameter));
        spriteRenderer.color = Color.LerpUnclamped(initialColor, targetColor, curve.Evaluate(tParameter));
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();
        }
    }
    private void StartTween()
    {
        tParameter = 0;
        currentTime = 0;
        initialPos = transform.position;
        targetPos = target.position;
    }
}
