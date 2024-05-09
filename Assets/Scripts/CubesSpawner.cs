using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private PositionRandomizer _positionRandomizer;
    [SerializeField] private Transform _cubesParent;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private float _scaleDivider;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;

    private List<Cube> _tempCubes;

    public event Action<Cube> CubeSpawned;
    public event Action<Cube, List<Cube>> CubesGenerated;

    private void Awake()
    {
        _tempCubes = new List<Cube>();
    }

    public void GenerateCubes(Cube cube)
    {
        if (cube.TryDivide())
        {
            int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);

            for (int i = 0; i < cubesCount; i++)
            {
                SpawnCube(cube);
            }
        }

        CubesGenerated?.Invoke(cube, _tempCubes);

        _tempCubes.Clear();
    }

    private void SpawnCube(Cube tempCube)
    {
        Cube cube = _cubePool.GetCube();
        cube.Init(tempCube.CurrentSeparationPersent, tempCube.GetReductionsNumber);
        cube.transform.parent = _cubesParent;
        cube.transform.position = _positionRandomizer.GetPosition(tempCube, _scaleDivider);
        cube.transform.localScale = tempCube.transform.localScale / _scaleDivider;
        cube.gameObject.SetActive(true);

        _tempCubes.Add(cube);
        CubeSpawned?.Invoke(cube);
    }
}