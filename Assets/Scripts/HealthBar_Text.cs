using TMPro;
using UnityEngine;

public class HealthBar_Text : MonoBehaviour
{
    [SerializeField] private Health _player;

    [SerializeField] private TMP_Text _textHealth;

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
        _textHealth.text = $"{_player.CurrentHealth}/{_player.MaxHealth}";
    }
}
