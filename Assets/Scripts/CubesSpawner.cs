using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;
using Random = UnityEngine.Random;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private RayCreator _rayCreator;
    [SerializeField] private int _startCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private float _separationPersent;
    [SerializeField] private float _divider;
    [SerializeField] private float _radius;
    [SerializeField] private float _minPos;
    [SerializeField] private float _maxPos;

    private List<Cube> _generatedCubes;
    private float _maxSeparationPersent;

    public event Action<Cube> CubeSpawned;

    private void Awake()
    {
        _generatedCubes = new List<Cube>();
        _maxSeparationPersent = _separationPersent;

        GenerateStartCubes();
    }

    private void OnEnable()
    {
        _rayCreator.OnCubeClicked += GenerateCubes;
    }
    private void OnDisable()
    {
        _rayCreator.OnCubeClicked -= GenerateCubes;
    }

    private void GenerateStartCubes()
    {
        for (int i = 0; i < _startCubesCount; i++)
        {
            SpawnCube();
        }
    }

    private void GenerateCubes()
    {
        _generatedCubes.Clear();

        if (Random.Range(0, _maxSeparationPersent) <= _separationPersent)
        {
            int cubesCount = Random.Range(0, _maxCubesCount);

            for (int i = 0; i < cubesCount; i++)
            {
                SpawnCube();
            }

            _separationPersent /= _divider;
        }
    }

    private void SpawnCube()
    {
        Vector3 spawnPosition = GetRandomPosition();

        if (Physics.OverlapSphere(spawnPosition, _radius).Length == 0)
        {
            Cube cube = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Cube>();
            cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            cube.AddComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 50);
            cube.transform.position = spawnPosition;
            cube.transform.gameObject.layer = LayerMask.NameToLayer("Cube");
            _generatedCubes.Add(cube);

            CubeSpawned?.Invoke(cube);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(_minPos, _maxPos), Random.Range(1, _maxPos), Random.Range(_minPos, _maxPos));
    }
}
