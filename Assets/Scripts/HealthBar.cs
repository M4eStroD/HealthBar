using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private Slider _healthBar;

    public Health CurrentHealth => _health;
    public Slider Bar => _healthBar;

    private void OnEnable()
    {
        _health.HealthChanged += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeHealthBar;
    }

    protected virtual void ChangeHealthBar()
    {
        float reductionFactor = 100;

        _healthBar.value = GetPercentBar() / reductionFactor;
    }

    protected float GetPercentBar()
    {
        float hundredProcent = 100;

        return _health.CurrentHealth * hundredProcent / _health.MaxHealth;
    }
}
