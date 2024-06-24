using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Projectile : Poolable
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Shooter _owner;
    private ProjectilePool _pool;

    public Shooter Owner => _owner;
    public ProjectilePool Pool => _pool;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 direction, Shooter shooter, ProjectilePool projectilePool)
    {
        _pool = projectilePool;
        _owner = shooter;
        _rigidbody2D.velocity = direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out Projectile projectile))
        {
            Pool.PutObject(this);
        }
    }
}
