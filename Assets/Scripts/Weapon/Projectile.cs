using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : Poolable
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Shooter _owner;

    public Shooter Owner => _owner;

    public event Action<Projectile> Destroyed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 direction, Shooter shooter)
    {
        _owner = shooter;
        _rigidbody2D.velocity = direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isDestroyed = false;

        if (collision.transform.TryGetComponent(out Projectile projectile))
        {
            isDestroyed = true;
        }

        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            if (enemy.Shooter != _owner)
            {
                isDestroyed = true;
            }
        }

        if (isDestroyed) 
        {
            Destroyed?.Invoke(this);
        }
    }
}
