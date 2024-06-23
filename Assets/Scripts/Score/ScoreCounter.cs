using System;
using System.Collections;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _workFrequency;
    [SerializeField] private int _scoreFrequency;

    private int _score;
    private Coroutine _coroutine;
    private WaitForSeconds _sleep;

    public event Action<int> ScoreChanged;

    private void Start()
    {
        _sleep = new WaitForSeconds(_workFrequency);
        _coroutine = StartCoroutine(ChangeScore());
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    private IEnumerator ChangeScore()
    {
        while (true)
        {
            yield return _sleep;
            _score += _scoreFrequency;
            ScoreChanged?.Invoke(_score);
        }
    }
}
