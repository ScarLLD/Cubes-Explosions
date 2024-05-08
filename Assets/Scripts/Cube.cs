using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _maxSeparationPersent;
    [SerializeField] private float _divider;

    private float _currentSeparationPersent;

    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();

        _currentSeparationPersent = _maxSeparationPersent;
    }

    public bool TryDivide()
    {
        if (Random.Range(0, _maxSeparationPersent) <= _currentSeparationPersent)
        {
            _currentSeparationPersent /= _divider;
            return true;
        }

        return false;
    }
}