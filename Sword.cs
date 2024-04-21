using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 2;

    public event EventHandler OnSwordSwing;
    private PolygonCollider2D _polygonCollider2D;


    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        AttackColliderTurnOff();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyCharacter enemyEntity))
            enemyEntity.TakeDamage(_damageAmount);
    }

    private void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    private void ToggleAttackCollider()
    {
        AttackColliderTurnOff();
        AttackColliderTurnOn();
    }

    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    public void PerformAttack()
    {
        ToggleAttackCollider();
        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }
}