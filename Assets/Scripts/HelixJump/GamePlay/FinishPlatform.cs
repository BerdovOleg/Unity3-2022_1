using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    public Vector3 FinishPoint;

    private void Start()
    {
        FinishPoint = transform.position;
    }
}
