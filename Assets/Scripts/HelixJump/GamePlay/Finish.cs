using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        player.ReachFinish();
    }
}
