using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPuzScript : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy;
    private Vector3 CameraToConfitieiOffset = new Vector3(0, 5, -10);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera.main.transform.position - CameraToConfitieiOffset;
        Destroy(gameObject, _timeToDestroy);
    }
}
