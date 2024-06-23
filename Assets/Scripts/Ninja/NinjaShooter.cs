using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShootAbility))]
public class NinjaShooter : Shooter
{
    [SerializeField] private KeyCode _shootKey;

    private void Update()
    {
        if(IsCanShoot)
        {
            if (Input.GetKeyDown(_shootKey))
            {
                Shoot(transform.right);
            }
        }
    }
}
