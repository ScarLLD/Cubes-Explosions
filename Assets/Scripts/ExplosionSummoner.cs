using System.Collections.Generic;
using UnityEngine;

public class ExplosionSummoner : MonoBehaviour
{
    [SerializeField] private CubesStorage _storage;
    [SerializeField] private CubesSpawner _spawner;
    [SerializeField] private int _explosionForce;
    [SerializeField] private int _explosionRadius;

    private void OnEnable()
    {
        _spawner.CubesGenerated += ChooseTargets;
    }

    private void OnDisable()
    {
        _spawner.CubesGenerated -= ChooseTargets;
    }

    private void ChooseTargets(Cube originCube, List<Cube> cubes)
    {
        if (cubes.Count > 0)
            SummonExplosion(originCube.transform.position,
                cubes, _explosionForce, _explosionRadius);
        else
            SummonExplosion(originCube.transform.position, _storage.GetCubes(),
                _explosionForce * originCube.GetReductionsNumber,
                _explosionRadius * originCube.GetReductionsNumber);
    }

    private void SummonExplosion(Vector3 explosionPosition,
        List<Cube> cubes, int force, int radius)
    {
        Debug.Log($"Force: {force} | Raduis: {radius}");

        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].Rigidbody.AddExplosionForce
            (force, explosionPosition, radius);
        }
    }
}
