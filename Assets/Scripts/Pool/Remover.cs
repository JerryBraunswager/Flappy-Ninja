using UnityEngine;

public class Remover<TKey, TValue> : MonoBehaviour where TValue : Poolable where TKey : Pool<TValue>
{
    [SerializeField] private TKey _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TValue poolable))
        {
            _pool.PutObject(poolable);
        }
    }
}
