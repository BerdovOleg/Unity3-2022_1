using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] Player player;
    [SerializeField] Vector3 PlatformToCameraOffset;

    // Update is called once per frame
    void Update()
    {
        if (player.CurrentPlatform == null) return;
        Vector3 targetPosition = player.CurrentPlatform.transform.position + PlatformToCameraOffset;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
