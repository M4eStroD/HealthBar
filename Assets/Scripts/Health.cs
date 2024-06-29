using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    public event Action HealthChanged;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        HealthChanged?.Invoke();
    }

    public void Heal(int healValue)
    {
        CurrentHealth += healValue;

        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;

        HealthChanged?.Invoke();
    }
}
