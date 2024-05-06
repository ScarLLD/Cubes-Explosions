using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private RayCreator _rayCreator;
    [SerializeField] private PositionRandomizer _positionRandomizer;
    [SerializeField] private ExplosionSummoner _explosionSummoner;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _startCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private float _separationPersent;
    [SerializeField] private float _divider;

    private float _maxSeparationPersent;

    public event Action<Cube> CubeSpawned;

    private void Awake()
    {
        _maxSeparationPersent = _separationPersent;
    }

    private void OnEnable()
    {
        _rayCreator.OnCubeClicked += GenerateCubes;
    }
    private void OnDisable()
    {
        _rayCreator.OnCubeClicked -= GenerateCubes;
    }

    private void GenerateCubes(Cube cube)
    {
        if (Random.Range(0, _maxSeparationPersent) <= _separationPersent)
        {
            int cubesCount = Random.Range(0, _maxCubesCount);

            for (int i = 0; i < cubesCount; i++)
            {
                SpawnCube(cube);
            }

            _separationPersent /= _divider;
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

            CubeSpawned?.Invoke(cube);
        }
    }
}