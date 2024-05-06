using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private CubesSpawner spawner;

    private void OnEnable()
    {
        spawner.CubeSpawned += SetColor;
    }

    private void OnDisable()
    {
        spawner.CubeSpawned -= SetColor;
    }

    private void SetColor(Cube cube)
    {
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
