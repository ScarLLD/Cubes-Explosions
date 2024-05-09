using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Cube _cubePrefab;

    private Queue<Cube> _cubes;

    private void Awake()
    {
        _cubes = new Queue<Cube>();
    }

    public void PutCube(Cube cube)
    {
        _cubes.Enqueue(cube);
        cube.gameObject.SetActive(false);
        cube.transform.parent = _container;
    }

    public Cube GetCube()
    {
        if (_cubes.Count == 0)
            return Instantiate(_cubePrefab);

        return _cubes.Dequeue();
    }
}
