using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Player player;

    private int _damage = 10;
    private int _heal = 10;

    public void DealDamage()
    {
        player.TakeDamage(_damage);
    }

    public void Heal()
    {
        player.Heal(_heal);
    }
}
