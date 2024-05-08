using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private CubesSpawner _spawner;

    private void OnEnable()
    {
        _spawner.CubeSpawned += SetColor;
    }

    private void OnDisable()
    {
        _spawner.CubeSpawned -= SetColor;
    }

    private void SetColor(Cube cube)
    {
        cube.Renderer.material.color = Random.ColorHSV();
    }
}