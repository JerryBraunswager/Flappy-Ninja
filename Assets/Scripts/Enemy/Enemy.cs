using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(ShootAbility))]
public class Enemy : Poolable
{
    public event Action<Enemy> Died;

    public EnemyShooter Shooter { get; private set; }

    public ShootAbility ShootAbility { get; private set; }

    private void Awake()
    {
        Shooter = GetComponent<EnemyShooter>();
        ShootAbility = GetComponent<ShootAbility>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isDead = false;

        if(collision.transform.TryGetComponent(out Projectile projectile))
        {
            if(projectile.Owner != Shooter) 
            {
                isDead = true;
            }
        }

        if (isDead)
        {
            Died?.Invoke(this);
        }
    }

}
