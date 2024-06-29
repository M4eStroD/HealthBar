using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _player;

    [SerializeField] private Slider _healthBar;

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
        float reductionFactor = 100;

        _healthBar.value = GetPercentBar() / reductionFactor;
    }

    private float GetPercentBar()
    {
        float hundredProcent = 100;

        return _player.CurrentHealth * hundredProcent / _player.MaxHealth;
    }
}
