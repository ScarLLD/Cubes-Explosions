using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionSummoner : MonoBehaviour
{
    [SerializeField] private CubesSpawner _spawner;
    [SerializeField] private int explosionForce;
    [SerializeField] private int explosionRadius;

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
            cubes[i].AddComponent<Rigidbody>().AddExplosionForce
            (explosionForce, explosionPosition, explosionRadius, 10, ForceMode.Impulse);
        }
    }
}
