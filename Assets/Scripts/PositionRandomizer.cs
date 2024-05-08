using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField] private float _minXPos;
    [SerializeField] private float _maxXPos;
    [SerializeField] private float _minYPos;
    [SerializeField] private float _maxYPos;
    [SerializeField] private float _minZPos;
    [SerializeField] private float _maxZPos;

    private Collider[] _colliders;

    public bool TryGetPosition(Cube cube, out Vector3 tempPosition)
    {
        tempPosition = Vector3.zero;

        Vector3 randomPosition = new
            (Random.Range(_minXPos, _maxXPos),
            Random.Range(_minYPos, _maxYPos),
            Random.Range(_minZPos, _maxZPos));

        if (Physics.OverlapBoxNonAlloc(randomPosition, cube.transform.localScale / 2, _colliders) == 0)
            tempPosition = randomPosition;

        return tempPosition != Vector3.zero;
    }
}