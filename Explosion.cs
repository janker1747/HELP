using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _radius = 1000f;
    public float _forse = 1000f;
    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        if (_spawner != null)
        {
            _spawner.OnNotSpawn += Explode;
        }
    }

    private void OnDisable()
    {
        if (_spawner != null)
        {
            _spawner.OnNotSpawn -= Explode;
        }
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody = colliders[i].attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_forse, transform.position, _radius);
            }
        }
    }
}
