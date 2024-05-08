using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private PositionRandomizer _positionRandomizer;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _cubesParent;
    [SerializeField] private float _scaleDivider;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;

    private List<Cube> _cubes;

    public event Action<Cube> CubeSpawned;
    public event Action<Vector3, List<Cube>> CubesGenerated;

    private void Awake()
    {
        _cubes = new List<Cube>();
    }

    public void GenerateCubes(Cube cube)
    {
        if (cube.TryDivide())
        {
            int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);
            _cubes.Clear();

            for (int i = 0; i < cubesCount; i++)
            {
                SpawnCube(cube);
            }

            CubesGenerated?.Invoke(cube.transform.position, _cubes);
        }
    }

    private void SpawnCube(Cube tempCube)
    {
        Cube cube = Instantiate(_cubePrefab, 
            _positionRandomizer.GetPosition(tempCube, _scaleDivider), Quaternion.identity, _cubesParent);
        cube.transform.localScale = tempCube.transform.localScale / _scaleDivider;

        _cubes.Add(cube);
        CubeSpawned?.Invoke(cube);
    }
}