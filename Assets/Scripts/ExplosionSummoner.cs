using System.Collections.Generic;
using UnityEngine;

public class ExplosionSummoner : MonoBehaviour
{
    [SerializeField] private CubesSpawner _spawner;
    [SerializeField] private int _explosionForce;
    [SerializeField] private int _explosionRadius;

    private void OnEnable()
    {
        _spawner.CubesGenerated += SummonExplosion;
    }

    private void OnDisable()
    {
        _spawner.CubesGenerated -= SummonExplosion;
    }

    private void SummonExplosion(Vector3 explosionPosition, List<Cube> cubes)
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].Rigidbody.AddExplosionForce
            (_explosionForce, explosionPosition, _explosionRadius, 10, ForceMode.Impulse);
        }
    }
}
