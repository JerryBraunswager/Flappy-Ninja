using System;
using UnityEngine;

[RequireComponent(typeof(ShootAbility))]
[RequireComponent(typeof(NinjaMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(NinjaCollisionHandler))]
public class Ninja : MonoBehaviour
{
    [SerializeField] private ProjectilePool _projectilePool;

    private NinjaMover _ninjaMover;
    private ScoreCounter _scoreCounter;
    private NinjaCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<NinjaCollisionHandler>();
        _ninjaMover = GetComponent<NinjaMover>();
        GetComponent<ShootAbility>().Init(_projectilePool);
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision()
    {
        GameOver?.Invoke(); 
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _ninjaMover.Reset();
    }
}
