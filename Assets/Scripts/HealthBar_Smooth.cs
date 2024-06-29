using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Smooth : MonoBehaviour
{
    [SerializeField] private Health _player;

    [SerializeField] private Slider _healthBar;

    private float _stepHealthChange = 0.5f;
    private float _currentStep = 0;

    private bool _isActive = false;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHealthBar;
    }

    private void ChangeHealthBar()
    {
        _currentStep += _stepHealthChange;

        if (_isActive == false)
            StartCoroutine(HealthBar());
    }

    private float GetPercentBar()
    {
        float hundredProcent = 100;

        return _player.CurrentHealth * hundredProcent / _player.MaxHealth;
    }

    private IEnumerator HealthBar()
    {
        float reductionFactor = 100;
        _isActive = true;

        while (_healthBar.value != GetPercentBar() / reductionFactor)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, GetPercentBar() / reductionFactor, _currentStep * Time.deltaTime);
            yield return null;
        }

        _currentStep = 0;
        _isActive = false;
    }
}
