using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    public Vector3 StartPoint;

    private void Start()
    {
        StartPoint = transform.position;
    }
}
