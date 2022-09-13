using UnityEngine;


public class Platform : MonoBehaviour
{
    public Sector[] Sectors;
    public bool Ready = false;
    public GameObject SectorDestriy;

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
            
            if (transform.position.y > player.gameObject.transform.position.y & !TryGetComponent<StartPlatform>(out StartPlatform platform))
            {
                Debug.Log("Player is Exit!");
                player.BlockComplited();
                for (int i = 0; i < Sectors.Length; i++)
                {
                    if (!Sectors[i].gameObject.active) continue;
                    var destroy = Instantiate(SectorDestriy, Sectors[i].transform.position, Sectors[i].transform.rotation);
                    Destroy(destroy, 2f);
                }
                gameObject.SetActive(false);
            }
        }
    }
}
