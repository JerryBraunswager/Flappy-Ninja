using System;
using UnityEngine;

[RequireComponent(typeof(Ninja))]
[RequireComponent(typeof(NinjaShooter))]
public class NinjaCollisionHandler : MonoBehaviour
{
    private NinjaShooter _shooter;

    public event Action CollisionDetected;

    private void Awake()
    {
        _shooter = GetComponent<NinjaShooter>();
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isDead = false;

        if (other.TryGetComponent(out Projectile projectile))
        {
            if(projectile.Owner != _shooter)
            {
                isDead = true;
            }
        }
        else
        {
            isDead = true;
        }

        if(isDead)
        {
            CollisionDetected?.Invoke();
        }
    }
}
