using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const float IntervalForSeconds = 0.5f;

    private bool _isDecrease;
    private Coroutine _jobUpdateNumber;

    public int Number { get; private set; }

    private void OnEnable()
    {
        _jobUpdateNumber = StartCoroutine(UpdateNumber());
    }

    private void OnDisable()
    {
        if (_jobUpdateNumber == null)
            return;

        StopCoroutine(_jobUpdateNumber);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDecrease = !_isDecrease; 
        }
    }

    private IEnumerator UpdateNumber()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(IntervalForSeconds);

        while (true)
        {
            Number = _isDecrease ? Number - 1 : Number + 1;
            Debug.Log(Number);
            yield return waitForSeconds;
        }
    }
}
