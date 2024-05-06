using Unity.VisualScripting;
using UnityEngine;

public class ExplosionSummoner : MonoBehaviour
{
    [SerializeField] private CubesSpawner spawner;
    [SerializeField] private int explosionForce;
    [SerializeField] private int explosionRadius;

    private void OnEnable()
    {
        spawner.CubeSpawned += SummonExplosion;
    }

    private void OnDisable()
    {
        spawner.CubeSpawned -= SummonExplosion;
    }

    public void SummonExplosion(Cube cube)
    {
        cube.AddComponent<Rigidbody>().AddExplosionForce
            (explosionForce, cube.transform.position, explosionRadius, 1f, ForceMode.Impulse);
    }
}
