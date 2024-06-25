using UnityEngine;

public class ShootAbility : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Projectile _projectile;
    
    private ProjectilePool _projectilePool;

    public void Init(ProjectilePool projectilePool)
    {
        _projectilePool = projectilePool;
    }

    public void SpawnProjectile(Vector3 direction, Shooter shooter)
    {
        var projectile = _projectilePool.GetObject();
        projectile.Destroyed += PutProjectile;
        projectile.gameObject.SetActive(true);
        projectile.transform.position = _shootPoint.position;
        projectile.Init(direction, shooter);
    }

    private void PutProjectile(Projectile projectile)
    {
        _projectilePool.PutObject(projectile);
        projectile.Destroyed -= PutProjectile;
    }
}
