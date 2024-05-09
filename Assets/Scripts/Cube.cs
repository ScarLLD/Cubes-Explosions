using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _reductionsNumber;
    [SerializeField] private float _maxSeparationPersent;
    [SerializeField] private float _divider;

    private Renderer _renderer;

    public Rigidbody Rigidbody { get; private set; }
    public float CurrentSeparationPersent { get; private set; }
    public int GetReductionsNumber => _reductionsNumber;

    private void OnEnable()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();

        CurrentSeparationPersent = _maxSeparationPersent;
    }

    public void Init(float currentSeparationPersent, int reductionsNumber)
    {
        CurrentSeparationPersent = currentSeparationPersent;
        _reductionsNumber = ++reductionsNumber;
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