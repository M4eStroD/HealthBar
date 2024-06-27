using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;

    public Action OnHealthChange;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        OnHealthChange?.Invoke();
    }

    public void Heal(int healValue)
    {
        CurrentHealth += healValue;

        OnHealthChange?.Invoke();
    }
}
