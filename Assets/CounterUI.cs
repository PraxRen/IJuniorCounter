using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textUI;

    private void Update()
    {
        _textUI.text = _counter.Number.ToString();
    }
}
