using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textUI;

    private void OnEnable()
    {
        _counter.Updated += OnUpdate;
    }

    private void OnDisable()
    {
        _counter.Updated -= OnUpdate;
    }

    private void OnUpdate(int number)
    {
        _textUI.text = number.ToString();
    }
}
