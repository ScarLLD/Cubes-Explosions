using System;
using UnityEngine;

public class RayCreator : MonoBehaviour
{
    [SerializeField] private LayerMask _cubeLayer;
    [SerializeField] private float _rayDirection;

    public event Action OnCubeClicked;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit _hit, _rayDirection, _cubeLayer))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Destroy(_hit.transform.gameObject);
                OnCubeClicked?.Invoke();
            }
        }
    }
}
