using UnityEngine;

public class RayCreator : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CubesSpawner _spawner;
    [SerializeField] private LayerMask _cubeLayer;
    [SerializeField] private float _rayDirection;

    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyUp(KeyCode.Mouse0)
            && Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit, _rayDirection, _cubeLayer)
            && hit.transform.TryGetComponent(out Cube cube))
        {
            _spawner.GenerateCubes(cube);
            Destroy(cube.gameObject);
        }
    }
}