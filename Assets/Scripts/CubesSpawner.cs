using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private PositionRandomizer _positionRandomizer;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private float _maxSeparationPersent;
    [SerializeField] private float _separationDivider;

    private List<Cube> _cubes;
    private float _currentSeparationPersent;

    public event Action<Cube> CubeSpawned;
    public event Action<Vector3, List<Cube>> CubesGenerated;

    private void Awake()
    {
        _cubes = new List<Cube>();
        _currentSeparationPersent = _maxSeparationPersent;
    }

    public void GenerateCubes(Cube cube)
    {
        if (Random.Range(0, _maxSeparationPersent) <= _currentSeparationPersent)
        {
            int cubesCount = Random.Range(0, _maxCubesCount);
            _cubes.Clear();

            for (int i = 0; i < cubesCount; i++)
            {
                SpawnCube(cube);
            }

            CubesGenerated?.Invoke(cube.transform.position, _cubes);

            _currentSeparationPersent /= _separationDivider;
        }
    }

    private void SpawnCube(Cube tempCube)
    {
        if (_positionRandomizer.TryGetPosition(tempCube, out Vector3 randomPosition))
        {
            Cube cube = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Cube>();
            cube.transform.position = randomPosition;
            cube.transform.localScale = tempCube.transform.localScale / 2;
            cube.transform.gameObject.layer = LayerMask.NameToLayer("Cube");

            _cubes.Add(cube);
            CubeSpawned?.Invoke(cube);
        }
    }
}