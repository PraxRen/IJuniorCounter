using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const float IntervalForSeconds = 0.5f;

    private Coroutine _jobUpdateNumber;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(IntervalForSeconds);

    public int Number { get; private set; }

    public event Action<int> Updated;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(IntervalForSeconds);
        _jobUpdateNumber = StartCoroutine(UpdateNumber());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_jobUpdateNumber != null)
            {
                StopCoroutine(_jobUpdateNumber);
                _jobUpdateNumber = null;
            }
            else
            {
                _jobUpdateNumber = StartCoroutine(UpdateNumber());
            }
        }
    }

    private IEnumerator UpdateNumber()
    {
        while (true)
        {
            Number++;
            Updated?.Invoke(Number);
            yield return _waitForSeconds;
        }
    }
}
