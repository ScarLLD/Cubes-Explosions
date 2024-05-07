using UnityEngine;

public class RayCreator : MonoBehaviour
{
    [SerializeField] private CubesSpawner _spawner;
    [SerializeField] private LayerMask _cubeLayer;
    [SerializeField] private float _rayDirection;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction,
            out RaycastHit _hit, _rayDirection, _cubeLayer))
        {
            if (Input.GetKey(KeyCode.Mouse0) && _hit.transform.TryGetComponent(out Cube cube))
            {
                _spawner.GenerateCubes(cube);
                Destroy(cube.gameObject);
            }
        }
    }
}