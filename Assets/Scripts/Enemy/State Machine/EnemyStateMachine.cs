using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _startState;

    private EnemyState _currentState;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnEnemyDied;
    }

    private void Start()
    {
        ResetState(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
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
            _currentState.Enter(_enemy.CurrentTarget);
        }
    }

    private void ResetState(EnemyState startState)
    {
        _currentState = startState;
        
        if (_currentState != null)
        {
            _currentState.Enter(_enemy.CurrentTarget);
        }
    }

    private void OnEnemyDied()
    {
        Transit(_startState);
    }
}
