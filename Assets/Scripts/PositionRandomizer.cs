using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField] private float _maxPos;
    [SerializeField] private float _minPos;

    public Vector3 GetPosition(Cube cube, float scaleDivider)
    {
        _maxPos = cube.transform.localScale.x / scaleDivider;
        _minPos = -_maxPos;

        Vector3 randomPosition = new
            (Random.Range(_minPos, _maxPos),
            Random.Range(_minPos, _maxPos),
            Random.Range(_minPos, _maxPos));

        return cube.transform.position += randomPosition;
    }
}