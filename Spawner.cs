using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    public event Action<GameObject> notSpawn;

    private static float _currentChance = 100f;

    private void OnEnable()
    {
        _prefab.Destroyed += OnCubeDestroyed;
    }

    private void OnDisable()
    {
        _prefab.Destroyed -= OnCubeDestroyed;
    }

    private void OnCubeDestroyed(Cube destroyedCube)
    {
        SpawnChance(destroyedCube.gameObject);
    }

    private void SpawnChance(GameObject destroedCube)
    {
        float minValue = 0;
        float maxValue = 100;
        float randomValue = UnityEngine.Random.Range(minValue, maxValue);

        if (randomValue < _currentChance)
        {
            Debug.Log("–азделение произошло!" + _currentChance + "шанс не сработать" + randomValue);
            SpawnObject();
            _currentChance /= 2;
        }
        else
        {
            notSpawn?.Invoke(destroedCube);
        }
    }

    private void SpawnObject()
    {
        float minValue = 2f;
        float maxValue = 6f;

        float random = UnityEngine.Random.Range(minValue, maxValue);

        for (int i = 0; i < random; i++)
        {
            CreateObject();
        }
    }

    private void CreateObject()
    {
        Cube newCube = Instantiate(_prefab, transform.position = _prefab.transform.position + Vector3.up, Quaternion.identity);
        newCube.transform.localScale = _prefab.transform.localScale / 2;

        ChangeColors(newCube.gameObject);
    }

    private void ChangeColors(GameObject cube)
    {
        MeshRenderer renderer = cube.GetComponent<MeshRenderer>();

        if (renderer != null)
        {
            renderer.material.color = UnityEngine.Random.ColorHSV();
        }
    }
}