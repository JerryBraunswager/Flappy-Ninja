using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : Poolable
{
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    public IEnumerable<T> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T GetObject(out bool newObject)
    {
        newObject = false;

        if (_pool.Count == 0)
        {
            var poolable = Instantiate(_prefab);
            poolable.transform.parent = transform;
            newObject = true;
            return poolable;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T poolable)
    {
        _pool.Enqueue(poolable);
        poolable.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
