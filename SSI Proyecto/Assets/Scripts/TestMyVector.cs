using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVector : MonoBehaviour
{
    [SerializeField] private MyVector myFirstVector;
    [SerializeField] private MyVector mySecondVector;
    private MyVector myThirdVector;
    private MyVector myFourthVector;

    [SerializeField][Range(0,1)] float interpolationRate;

    void Update()
    {
        myFirstVector.Draw(Color.blue);
        mySecondVector.Draw(Color.red);

        myThirdVector = myFirstVector.Lerp_(mySecondVector, interpolationRate);
        myThirdVector.Draw(Color.green);

        myFourthVector = myThirdVector - myFirstVector;
        myFourthVector.Draw(myFirstVector, Color.white);
    }
}
