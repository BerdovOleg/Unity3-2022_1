using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMyPos : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI Text;

    private void Start()
    {
        Text.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = transform.position.x + "," + transform.position.y + "," + transform.position.z;
    }
}
