using UnityEngine;

[System.Serializable]
public struct MyVector
{
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    //metodo suma
    public MyVector Sum(MyVector other)
    {
        return new MyVector(
            x + other.x,
            y + other.y
        );
    }
    public static MyVector operator +(MyVector a, MyVector b)
    {
        return a.Sum(b);
    }
    //metodo resta
    public MyVector Sub(MyVector other)
    {
        return new MyVector(
            x - other.x,
            y - other.y
        );
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return a.Sub(b);
    } 
    //metodo multiplicacion por escalar 
    public MyVector Scale(float c)
    {
        return new MyVector(
            x * c,
            y * c
        );
    }
    public static MyVector operator *(MyVector a, float c)
    {
        return a.Scale(c);
    }
    public static MyVector operator *(float c, MyVector a)
    {
        return a.Scale(c);
    }
    //metodo lerp
    public MyVector Lerp_(MyVector b, float c)
    {
        return this + (b - this) * c;
    }
    //metodo transposicion Vector3 to MyVector
    public static implicit operator Vector3(MyVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public static implicit operator MyVector(Vector3 a)
    {
        return new MyVector(a.x, a.y);
    }


    public void Draw(Color color)
    {
        Debug.DrawLine(
            new Vector3(0, 0, 0),
            new Vector3(x, y, 0),
            color,
            0
        );
    }
    public void Draw(MyVector a,Color color)
    {
        Debug.DrawLine(
            new Vector3(a.x, a.y, 0),
            new Vector3(a.x + x, y + a.y, 0),
            color,
            0
        );
    }
    public override string ToString()
    {
        return $"(" + x +", " + y + ")";
    }
    public float magnitude => Mathf.Sqrt(x * x + y * y);
    public MyVector normalized
    {
        get
        {
            float distance = magnitude;
            if (distance < 0.0001f)
            {
                return new MyVector(0, 0);
            }
            return new MyVector(x / distance, y / distance);
        }
    }
    public void Normalize()
    {
        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / magnitudeCache;
            y = y / magnitudeCache;
        }
    }
}
