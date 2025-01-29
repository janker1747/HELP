using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ChangeColors(GameObject cube)
    {
        MeshRenderer renderer = cube.GetComponent<MeshRenderer>();

        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}
