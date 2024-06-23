using UnityEngine;

public class ProjectilePool : Pool<Projectile>
{
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _endGameScreen.RestartButtonClicked += DisableAlProjectiles;
    }

    private void DisableAlProjectiles()
    {
        for(int i = 0; i < transform.childCount; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
