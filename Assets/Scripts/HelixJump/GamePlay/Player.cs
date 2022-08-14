using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float BouseForce;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] GameManager Game;

    float max;

    public Platform CurrentPlatform;

    [SerializeField] private AudioClip clip;
    [SerializeField] SoundManger soundManger;

    public void ReachFinish()
    {
        rigidbody.velocity = Vector3.zero;
        Game.OnPlayerReachedFinish();
    }

    public void Bounce()
    {
        rigidbody.velocity = new Vector3(0, BouseForce, 0);
        soundManger.PlaySound(clip);
    }

    public void Die()
    {
        rigidbody.velocity = Vector3.zero;
        Game.OnPlayerDie();
    }

    public void BlockComplited()
    {
        Game.BlocksAdd();
    }

    private void Update()
    {
        if (rigidbody.velocity != Vector3.zero)
        {
            var speed = rigidbody.velocity.magnitude;
            if (max<speed)
            {
                max = speed;
                //print("speed: "+speed);
            }
            //print("max_speed: " + max);
        }
    }
}
