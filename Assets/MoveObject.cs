using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public void MoveObjectStepUp(float Input, int times, bool isX)
    {
        Vector3 Movement = new();

        if (isX) Movement = new (0, Input * times);
        if(!isX) Movement = new (Input * times, 0);

        transform.Translate(Movement);
    }
}
