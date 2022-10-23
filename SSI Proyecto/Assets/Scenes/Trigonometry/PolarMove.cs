using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarMove : MonoBehaviour
{
    [SerializeField] MyVector polarPoint;
    [SerializeField] float angularSpeed;
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAcceleration;

    void Update()
    {
        polarPoint.x += Time.deltaTime * radialSpeed;
        polarPoint.y += Time.deltaTime * angularSpeed;
        MyVector cartesianPoint = Polar2Cartesian(polarPoint);
        cartesianPoint.Draw(Color.yellow);
        transform.position = cartesianPoint;
        CheckBounds();
    }
    MyVector Polar2Cartesian(MyVector polar)
    {
        float x = Mathf.Cos(polar.y * Mathf.Deg2Rad) * polar.x;
        float y = Mathf.Sin(polar.y * Mathf.Deg2Rad) * polar.x;
        MyVector unitdir = new MyVector(x, y);
        return unitdir;
    }
    void CheckBounds()
    {
        if (Mathf.Abs(polarPoint.x) >= 5)
        {
            polarPoint.x = Mathf.Sign(polarPoint.x) * 5;
            if (Mathf.Abs(radialAcceleration) > 0)
            {
                radialAcceleration = -radialAcceleration;
                radialSpeed *= -1;
            }
            else
            {
                radialSpeed = -radialSpeed;
            }

        }
       
    }
}
