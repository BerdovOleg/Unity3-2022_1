using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] bool IsGood = true;
    [SerializeField] Material GoodTexture;
    [SerializeField] Material BadTexture;
    [SerializeField] GameObject splash;


    private void Awake()
    {
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        GetComponent<Renderer>().sharedMaterial = IsGood ? GoodTexture : BadTexture;
    }

    public void Deactive()
    { this.gameObject.SetActive(false); }


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.down);

        if (dot < 0.5) return;

        if (IsGood)
        {
            player.Bounce();
            var gObj = Instantiate(splash, transform.position + new Vector3(0, .45f, -4.5f), Quaternion.identity) as GameObject;
            gObj.transform.parent = gameObject.transform;
            gObj.transform.Rotate(new Vector3(90, 0, 0));
            Destroy(gObj, 1);
        }
        else
            player.Die();
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
