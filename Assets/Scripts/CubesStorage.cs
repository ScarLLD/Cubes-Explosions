using System.Collections.Generic;
using UnityEngine;

public class CubesStorage : MonoBehaviour
{
    [SerializeField] private CubesSpawner _cubeSpawner;

    private List<Cube> _cubes;

    private void Awake()
    {
        _cubes = new List<Cube>();
    }

    private void OnEnable()
    {
        _cubeSpawner.CubeSpawned += TakeCube;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeSpawned -= TakeCube;
    }

    private void TakeCube(Cube cube)
    {
        _cubes.Add(cube);
        cube.transform.parent = transform;
    }
}
