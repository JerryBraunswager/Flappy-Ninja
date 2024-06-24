using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : Poolable
{
    private EnemyShooter _shooter;

    public event Action<Enemy> Died;

    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isDead = false;

        if(collision.transform.TryGetComponent(out Projectile projectile))
        {
            if(projectile.Owner != _shooter) 
            { 
                projectile.Pool.PutObject(projectile);
                isDead = true;
            }
        }

        if (isDead)
        {
            Died?.Invoke(this);
        }
    }

}
