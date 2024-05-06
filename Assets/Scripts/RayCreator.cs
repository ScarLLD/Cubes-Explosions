using System;
using UnityEngine;

public class RayCreator : MonoBehaviour
{
    [SerializeField] private LayerMask _cubeLayer;
    [SerializeField] private float _rayDirection;

    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit _hit, _rayDirection, _cubeLayer))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                OnCubeClicked?.Invoke(_hit.transform.GetComponent<Cube>());
                Destroy(_hit.transform.gameObject);
            }
        }
    }
}
