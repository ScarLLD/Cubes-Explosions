using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _maxSeparationPersent;
    [SerializeField] private float _divider;

    private Renderer _renderer;

    public Rigidbody Rigidbody { get; private set; }
    public float CurrentSeparationPersent { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();

        _renderer.material.color = Random.ColorHSV();
        CurrentSeparationPersent = _maxSeparationPersent;
    }

    public void InitSeparationPersent(float currentSeparationPersent)
    {
        CurrentSeparationPersent = currentSeparationPersent;
    }

    public bool TryDivide()
    {
        if (Random.Range(0, _maxSeparationPersent) <= CurrentSeparationPersent)
        {
            CurrentSeparationPersent /= _divider;
            return true;
        }

        return false;
    }
}