﻿using System;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public event Action<int> ApplyHit = delegate { };


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==  "Projectile")
        {
            ApplyHit(1);
            Destroy(other.gameObject);

            AudioManager.Instance.Play(AudioManager.SoundType.HIT);
        }
    }
}
