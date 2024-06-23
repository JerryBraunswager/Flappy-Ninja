using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Projectile _projectile;
    
    private ProjectilePool _projectilePool;

    public ProjectilePool ProjectilePool => _projectilePool;

    public void Init(ProjectilePool projectilePool)
    {
        _projectilePool = projectilePool;
    }

    public void SpawnProjectile(Vector3 direction, Shooter shooter)
    {
        if(direction == null)
        {
            return;
        }

        var projectile = _projectilePool.GetObject();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = _shootPoint.position;
        projectile.Init(direction, shooter);
    }
}
