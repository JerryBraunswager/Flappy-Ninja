using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _sleepTime;

    private ShootAbility _shooter;
    private WaitForSeconds _sleep;
    private bool _isCanShoot;

    private void Awake()
    {
        _shooter = GetComponent<ShootAbility>();
    }

    private void Start()
    {
        _isCanShoot = false;
        _sleep = new WaitForSeconds(_sleepTime);
        StartCoroutine(ReloadShootAbility());
    }

    public ShootAbility ShootAbility => _shooter;

    protected bool IsCanShoot => _isCanShoot;

    protected void Shoot(Vector3 direction)
    {
        _shooter.SpawnProjectile(direction, this);
        _isCanShoot = false;
        StartCoroutine(ReloadShootAbility());
    }

    protected IEnumerator ReloadShootAbility()
    {
        yield return _sleep;
        _isCanShoot = true;
    }
}
