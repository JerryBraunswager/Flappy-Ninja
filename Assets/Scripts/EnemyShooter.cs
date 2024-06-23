using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootAbility))]
public class EnemyShooter : Shooter
{
    private void OnEnable()
    {
        StartCoroutine(ReloadShootAbility());
    }

    private void Update()
    {
        if (IsCanShoot)
        {
            Shoot(-transform.right);
        }
    }

}
