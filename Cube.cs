using System;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Destroyed;
    public Explosion _explosion;

    public void OnClick()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}