using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ShootAbility))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private float _sleepTime;

    private ShootAbility _shootAbility;
    private WaitForSeconds _sleep;

    public bool IsCanShoot { get; private set; }

    private void Awake()
    {
        _shootAbility = GetComponent<ShootAbility>();
    }

    private void Start()
    {
        IsCanShoot = false;
        _sleep = new WaitForSeconds(_sleepTime);
        StartCoroutine(ReloadShootAbility());
    }

    protected void Shoot(Vector3 direction)
    {
        if (IsCanShoot == false)
        {
            return;
        }

        _shootAbility.SpawnProjectile(direction, this);
        IsCanShoot = false;
        StartCoroutine(ReloadShootAbility());
    }

    protected IEnumerator ReloadShootAbility()
    {
        yield return _sleep;
        IsCanShoot = true;
    }
}
