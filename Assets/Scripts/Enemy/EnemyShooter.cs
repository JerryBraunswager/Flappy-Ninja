using UnityEngine;

public class EnemyShooter : Shooter
{
    private void OnEnable()
    {
        StartCoroutine(ReloadShootAbility());
    }

    private void Update()
    {
        Shoot(-transform.right);
    }

}
