using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VectorDemo : MonoBehaviour
{
    [SerializeField] Transform Obj1;
    [SerializeField] Transform Obj2;
    [SerializeField] TextMeshProUGUI text;
    public float a;
    public Vector3 plus;
    public Vector3 minus;
    public Vector3 proiz;


    // Update is called once per frame
    void Update()
    {
          a = Vector3.Distance(Obj1.position, Obj2.position);

        text.text = "Расстояние от Obj1 до Obj2: " + a;
        text.text += "\nСложение векторов: "+ plus.x+","+plus.y+","+plus.z;
        text.text += "\nВычитание векторов: " + minus.x + "," + minus.y + "," + minus.z;
        text.text += "\nУмножение вектора на растояние " + proiz.x + "," + proiz.y + "," + proiz.z;



    }

    private void OnDrawGizmos()
    {
        plus = Obj1.position + Obj2.position;
        minus = Obj1.position - Obj2.position;
        proiz = Obj1.position * a;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(0, 0, 0), plus);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(0, 0, 0), minus);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(0, 0, 0), proiz);

    }
}
