using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float _timeOfChange = 1f;

    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Coroutine _changedHealth;

    private void OnEnable()
    {
        _player.ChangedHealth += OnChangedHealth;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnChangedHealth;
    }

    private void OnChangedHealth(int value, int maxValue)
    {
        if (_changedHealth != null)
            StopCoroutine(_changedHealth);

        _changedHealth = StartCoroutine(ChangeHealth(value, maxValue));
    }

    private IEnumerator ChangeHealth(int value, int maxValue)
    {
        float normalizeValue = (float)value / maxValue;

        while (_slider.value != normalizeValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, normalizeValue, _timeOfChange * Time.deltaTime);

            yield return null;
        }
    }
}
