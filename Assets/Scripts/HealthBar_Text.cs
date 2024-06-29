using TMPro;
using UnityEngine;

public class HealthBar_Text : HealthBar
{
    [SerializeField] private TMP_Text _textHealth;

    protected override void ChangeHealthBar()
    {
        _textHealth.text = $"{CurrentHealth.CurrentHealth}/{CurrentHealth.MaxHealth}";
    }
}
