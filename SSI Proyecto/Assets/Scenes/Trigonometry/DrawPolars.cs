using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPolars : MonoBehaviour
{
    [SerializeField] private float angleDegree;
    [SerializeField] private float radius = 1;
    [SerializeField] private float angularvelocity;
    
    void Update()
    {
        angleDegree -= angularvelocity * Time.deltaTime;
        PolarToCartesian(angleDegree, radius).Draw(Color.green);
       
    }
    MyVector PolarToCartesian(float angle,float rad) 
    {
        float x = Mathf.Cos(angleDegree * Mathf.Deg2Rad);
        float y = Mathf.Sin(angleDegree * Mathf.Deg2Rad);
        MyVector unitdir = new MyVector(x * radius, y * radius);
        return unitdir;
    }
}
