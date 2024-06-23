using UnityEngine;

public class NinjaTracker : MonoBehaviour
{
    [SerializeField] private Ninja _ninja;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _ninja.transform.position.x + _xOffset;
        transform.position = position;
    }
}
