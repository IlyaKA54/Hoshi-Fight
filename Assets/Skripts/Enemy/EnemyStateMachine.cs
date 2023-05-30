using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyState _firstState;
    [SerializeField] private BrokenState _brokenState;
    [SerializeField] private HealthContainer _healthContainer;

    public PlayerStateMachine Player { get; private set; }

    private Rigidbody _rigidbody;
    private Animator _animator;
    private EnemyState _currentState;
    private float _minDamage;

    public event UnityAction<EnemyStateMachine> Died;

    private void OnEnable()
    {
        _healthContainer.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        _healthContainer.Died -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        enabled = false;
        _rigidbody.constraints = RigidbodyConstraints.None;
        Died?.Invoke(this);
    }

    private void Awake()
    {
        Player = FindObjectOfType<PlayerStateMachine>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator, Player);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        EnemyState nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(EnemyState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_rigidbody, _animator, Player);
        }
    }

    public bool ApplyDamage(Rigidbody rigidbody, float force)
    {
        if (force > _minDamage && _currentState != _brokenState)
        {
            _healthContainer.TakeDamage((int)force);
            Transit(_brokenState);
            _brokenState.ApplyDamage(rigidbody, force);
            return true;
        }

        return false;
    }
}
