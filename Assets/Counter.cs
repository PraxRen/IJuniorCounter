using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const float IntervalForSeconds = 0.5f;

    private bool _isRunning;

    public int Number { get; private set; }

    public event Action<int> Updated;

    private void Start()
    {
        StartCoroutine(UpdateNumber());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isRunning == false)
                StartCoroutine(UpdateNumber());
            else
                _isRunning = false;
        }
    }

    private IEnumerator UpdateNumber()
    {
        _isRunning = true;
        WaitForSeconds waitForSeconds = new WaitForSeconds(IntervalForSeconds);

        while (_isRunning)
        {
            Number++;
            Updated?.Invoke(Number);
            yield return waitForSeconds;
        }
    }
}
