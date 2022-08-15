using UnityEngine;


public class Platform : MonoBehaviour
{
    public Sector[] Sectors;
    public bool Ready = false;

    private void Awake()
    {
        Sectors = GetComponentsInChildren<Sector>();
        Ready = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.BlockComplited();
            gameObject.SetActive(false);
        }
    }
}
