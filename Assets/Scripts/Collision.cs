using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Rigidbody door;

    [SerializeField] Rigidbody[] bang;

    private void OnTriggerEnter(Collider other)
    {
        print("Enter Trigger");
        text.text += "\nEnter Trigger: "+ other.name;

        foreach (var item in bang)
        {
            item.AddForce(Vector3.forward * 20, ForceMode.VelocityChange);
        }
       // door.AddForce(Vector3.forward*20, ForceMode.VelocityChange);
    }

    private void OnTriggerExit(Collider other)
    {
        print("Exit Trigger");
        text.text += "\nExit Trigger: " + other.name;
    }

    private void OnTriggerStay(Collider other)
    {
       // print("Stay Trigger");
    }

}
