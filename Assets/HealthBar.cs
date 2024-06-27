using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private TMP_Text _textHealth;
    [SerializeField] private Slider _healthBar;

    private void OnEnable()
    {
        _player.OnHealthChange += ChangeHealthBar;
    }

    private void OnDisable()
    {
        _player.OnHealthChange -= ChangeHealthBar;
    }

    private void ChangeHealthBar()
    {
        _textHealth.text = $"{_player.CurrentHealth}/{_player.MaxHealth}";

        _healthBar.value = GetProcentBar();
    }

    private float GetProcentBar()
    {
        float hundredProcent = 100;

        return (_player.CurrentHealth * hundredProcent / _player.MaxHealth) / hundredProcent;
    }
}
