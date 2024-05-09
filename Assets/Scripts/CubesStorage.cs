using System.Collections.Generic;
using UnityEngine;

public class CubesStorage : MonoBehaviour
{
    [SerializeField] private CubesSpawner _spawner;

    private List<Cube> _cubes;

    private void TakeCube(Cube cube) => _cubes.Add(cube);
    public List<Cube> GetCubes() => _cubes;

    private void OnEnable()
    {
        _spawner.CubeSpawned += TakeCube;
    }

    private void OnDisable()
    {
        _spawner.CubeSpawned -= TakeCube;
    }

    private void Awake()
    {
        _cubes = new List<Cube>();
    }

}
